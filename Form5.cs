using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecipeGenius
{
    public partial class Form5 : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        string connectionString = "Data Source=ALVIN-AB\\SQLEXPRESS;Initial Catalog=RecipeGenius;Integrated Security=True";
        private Recipe selectedRecipe; // Store the selected recipe

        public Form5()
        {
            InitializeComponent();
            InitializeAsync();
        }

        public Form5(int selectedRecipeID)
        {
            InitializeComponent();
            InitializeAsync(selectedRecipeID);
        }

        private async Task InitializeAsync(int selectedRecipeID = -1)
        {
            try
            {
                await LoadDataAsync();
                LoadCategories();
                LoadProducts();

                if (selectedRecipeID != -1)
                {
                    await LoadSpecificRecipeAsync(selectedRecipeID);
                }
            }
            catch (Exception ex)
            {
                HandleError("InitializeAsync", ex);
            }
        }
        private void HandleError(string methodName, Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
            logger.Error(ex, $"{methodName} - An error occurred.");
        }


        private async Task LoadDataAsync()
        {
            try
            {
                List<Recipe> recipeDataList = await RetrieveDataFromDatabaseAsync();

                flowLayoutPanel1.Controls.Clear();

                foreach (Recipe data in recipeDataList)
                {
                    RecipeUserControl recipeUserControl = new RecipeUserControl(this, data, true);
                    recipeUserControl.SetImage(data.ImagePath);
                    recipeUserControl.SetTitle(data.Title);
                    flowLayoutPanel1.Controls.Add(recipeUserControl);
                }
            }
            catch (Exception ex)
            {
                HandleError("LoadDataAsync", ex);
            }
        }

        private async Task<List<Recipe>> RetrieveDataFromDatabaseAsync()
        {
            List<Recipe> recipeDataList = new List<Recipe>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string sqlQuery = "SELECT r.RecipeID, r.Title, r.ImagePath FROM Recipes r";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int recipeID = reader.GetInt32(0);
                            string title = reader.GetString(1);
                            string imagePath = reader.GetString(2);

                            Recipe recipe = new Recipe(recipeID, title, string.Empty, 0, "", imagePath, new List<RecipeIngredients>());
                            recipeDataList.Add(recipe);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError("RetrieveDataFromDatabaseAsync", ex);
            }

            return recipeDataList;
        }

        public void OpenTabPage1()
        {
            tabControl1.SelectedTab = tabPage1;
        }
        private void homeBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string getCategoryQuery = "SELECT CategoryID, CategoryName FROM Categories";
                    using (SqlCommand cmd = new SqlCommand(getCategoryQuery, connection))
                    {
                        DataTable categoryDataTable = new DataTable();
                        categoryDataTable.Load(cmd.ExecuteReader());

                        categoryComboBox.DataSource = categoryDataTable;
                        categoryComboBox.DisplayMember = "CategoryName";
                        categoryComboBox.ValueMember = "CategoryID";
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError("LoadCategories", ex);
            }
        }

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string getProductQuery = "SELECT ProductID, ProductName FROM Products";
                    using (SqlCommand cmd = new SqlCommand(getProductQuery, connection))
                    {
                        DataTable productDataTable = new DataTable();
                        productDataTable.Load(cmd.ExecuteReader());

                        ProductList.DataSource = productDataTable;
                        ProductList.DisplayMember = "ProductName";
                        ProductList.ValueMember = "ProductID";
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError("LoadProducts", ex);
            }
        }


        private async void btnSaveRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if essential fields are empty
                if (string.IsNullOrWhiteSpace(txtRecipeTitle.Text) ||
                    string.IsNullOrWhiteSpace(txtRecipeInstructions.Text) ||
                    categoryComboBox.SelectedValue == null ||
                    string.IsNullOrWhiteSpace(txtCookingTime.Text) ||
                    dataGridViewIngredients.Rows.Count == 0)
                {
                    MessageBox.Show("Please fill in all the required fields before saving.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit the method
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertRecipeQuery = "INSERT INTO Recipes (Title, RecipeDescription, CategoryID, CookingTime, ImagePath) " +
                        "VALUES (@Title, @Description, @Category, @CookingTime, @ImagePath); SELECT SCOPE_IDENTITY()";

                    using (SqlCommand cmd = new SqlCommand(insertRecipeQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Title", txtRecipeTitle.Text);
                        cmd.Parameters.AddWithValue("@Description", txtRecipeInstructions.Text);
                        cmd.Parameters.AddWithValue("@Category", categoryComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@CookingTime", txtCookingTime.Text);
                        cmd.Parameters.AddWithValue("@ImagePath", pictureBoxRecipe.Tag ?? DBNull.Value);

                        decimal recipeID = Convert.ToDecimal(cmd.ExecuteScalar());

                        foreach (DataGridViewRow row in dataGridViewIngredients.Rows)
                        {
                            int productID = (int)row.Cells["ProductList"].Value;
                            string quantity = row.Cells["QuantityBox"].Value?.ToString() ?? string.Empty;

                            string insertIngredientQuery = "INSERT INTO RecipeIngredients (RecipeID, ProductID, Quantity) " +
                                "VALUES (@RecipeID, @ProductID, @Quantity)";

                            using (SqlCommand ingredientCmd = new SqlCommand(insertIngredientQuery, connection))
                            {
                                ingredientCmd.Parameters.AddWithValue("@RecipeID", recipeID);
                                ingredientCmd.Parameters.AddWithValue("@ProductID", productID);
                                ingredientCmd.Parameters.AddWithValue("@Quantity", quantity);

                                ingredientCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Recipe added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                HandleError("btnSaveRecipe_Click", ex);
            }
        }



        private void ClearForm()
        {

            txtRecipeTitle.Clear();
            txtRecipeInstructions.Clear();
            categoryComboBox.SelectedIndex = -1;
            txtCookingTime.Clear();
            dataGridViewIngredients.Rows.Clear();
            pictureBoxRecipe.Image = null;
            pictureBoxRecipe.Tag = null;
        }

        private async Task LoadSpecificRecipeAsync(int recipeID)
        {
            try
            {
                selectedRecipe = await RetrieveRecipeFromDatabaseAsync(recipeID);

                // Populate form controls with recipe data
                txtRecipeTitle.Text = selectedRecipe.Title;
                txtRecipeInstructions.Text = selectedRecipe.RecipeDescription;
                categoryComboBox.SelectedValue = selectedRecipe.CategoryID;
                txtCookingTime.Text = selectedRecipe.CookingTime.ToString();

                // Load and display ingredients
                LoadIngredientsForRecipe(selectedRecipe.RecipeID);

                // Display the recipe image
                if (!string.IsNullOrEmpty(selectedRecipe.ImagePath))
                {
                    pictureBoxRecipe.Image = Image.FromFile(selectedRecipe.ImagePath);
                    pictureBoxRecipe.Tag = selectedRecipe.ImagePath;
                }
            }
            catch (Exception ex)
            {
                HandleError("LoadSpecificRecipeAsync", ex);
            }
        }

        private async Task<Recipe> RetrieveRecipeFromDatabaseAsync(int recipeID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string sqlQuery = "SELECT RecipeID, Title, RecipeDescription, CategoryID, CookingTime, ImagePath " +
                        "FROM Recipes WHERE RecipeID = @RecipeID";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RecipeID", recipeID);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new Recipe(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetInt32(3),
                                    reader.GetString(4),
                                    reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                                    new List<RecipeIngredients>());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError("RetrieveRecipeFromDatabaseAsync", ex);
            }

            return null;
        }


        private void LoadIngredientsForRecipe(int recipeID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string getIngredientsQuery = "SELECT ri.ProductID, p.ProductName, ri.Quantity " +
                        "FROM RecipeIngredients ri " +
                        "INNER JOIN Products p ON ri.ProductID = p.ProductID " +
                        "WHERE ri.RecipeID = @RecipeID";

                    using (SqlCommand cmd = new SqlCommand(getIngredientsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@RecipeID", recipeID);

                        DataTable ingredientsDataTable = new DataTable();
                        ingredientsDataTable.Load(cmd.ExecuteReader());

                        foreach (DataRow row in ingredientsDataTable.Rows)
                        {
                            int productID = (int)row["ProductID"];
                            string productName = row["ProductName"].ToString();
                            string quantity = row["Quantity"].ToString();

                            // Add the ingredients to the DataGridView
                            //dataGridViewIngredients.Rows.Add(productID, productName, quantity);
                            // Add a new row to the DataGridView
                            int rowIndex = dataGridViewIngredients.Rows.Add();
                            // Set the values in the DataGridView
                            dataGridViewIngredients.Rows[rowIndex].Cells["ProductList"].Value = productID; // ComboBox column
                            dataGridViewIngredients.Rows[rowIndex].Cells["QuantityBox"].Value = quantity; // Text-based column


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError("LoadIngredientsForRecipe", ex);
            }
        }


        private async Task UpdateIngredientsForRecipeAsync(int recipeID)
        {
            try
            {
                // Clear existing ingredients for the recipe
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string deleteIngredientsQuery = "DELETE FROM RecipeIngredients WHERE RecipeID = @RecipeID";

                    using (SqlCommand deleteCmd = new SqlCommand(deleteIngredientsQuery, connection))
                    {
                        deleteCmd.Parameters.AddWithValue("@RecipeID", recipeID);
                        await deleteCmd.ExecuteNonQueryAsync();
                    }
                }

                // Insert updated ingredients
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    foreach (DataGridViewRow row in dataGridViewIngredients.Rows)
                    {
                        int productID = (int)row.Cells["ProductList"].Value;
                        string quantity = row.Cells["QuantityBox"].Value?.ToString() ?? string.Empty;

                        string insertIngredientQuery = "INSERT INTO RecipeIngredients (RecipeID, ProductID, Quantity) " +
                            "VALUES (@RecipeID, @ProductID, @Quantity)";

                        using (SqlCommand insertCmd = new SqlCommand(insertIngredientQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@RecipeID", recipeID);
                            insertCmd.Parameters.AddWithValue("@ProductID", productID);
                            insertCmd.Parameters.AddWithValue("@Quantity", quantity);

                            await insertCmd.ExecuteNonQueryAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError("UpdateIngredientsForRecipeAsync", ex);
            }
        }


        private void pictureBoxRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.ico";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Store the selected image path in the PictureBox's Tag property
                        pictureBoxRecipe.Tag = openFileDialog.FileName;
                        // Display the selected image in the PictureBox
                        pictureBoxRecipe.Image = Image.FromFile(openFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError("pictureBoxRecipe_Click", ex);
            }
        }

        private void ingredientBtn_Click(object sender, EventArgs e)
        {
            dataGridViewIngredients.Rows.Add();
        }

        private async void updateBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Update the selected recipe
                if (selectedRecipe == null)
                {
                    MessageBox.Show("No recipe is selected for update.");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateRecipeQuery = "UPDATE Recipes SET Title = @Title, RecipeDescription = @Description, " +
                        "CategoryID = @Category, CookingTime = @CookingTime, ImagePath = @ImagePath WHERE RecipeID = @RecipeID";

                    using (SqlCommand cmd = new SqlCommand(updateRecipeQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@RecipeID", selectedRecipe.RecipeID);
                        cmd.Parameters.AddWithValue("@Title", txtRecipeTitle.Text);
                        cmd.Parameters.AddWithValue("@Description", txtRecipeInstructions.Text);
                        cmd.Parameters.AddWithValue("@Category", categoryComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@CookingTime", txtCookingTime.Text);
                        cmd.Parameters.AddWithValue("@ImagePath", pictureBoxRecipe.Tag ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }

                    // Update the ingredients
                    await UpdateIngredientsForRecipeAsync(selectedRecipe.RecipeID);
                    MessageBox.Show("Recipe updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                HandleError("updateBtn_Click_1", ex);
            }
        }

        private void btnDeleteRecipe_Click(object sender, EventArgs e)
        {
            if (selectedRecipe == null)
            {
                MessageBox.Show("No recipe is selected for deletion.");
                return;
            }

            // Confirm the deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this recipe?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Call the DeleteRecipe method with the selected recipe's ID
                    DeleteRecipe(selectedRecipe.RecipeID);
                    flowLayoutPanel1.Controls.Clear();
                    LoadDataAsync(); // Reload the recipes
                    ClearForm(); // Clear the form
                }
                catch (Exception ex)
                {
                    HandleError("Recipe Deletion", ex);
                }
            }
        }


        private async void DeleteRecipe(int recipeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // First, delete recipe ingredients
                        string deleteIngredientsQuery = "DELETE FROM RecipeIngredients WHERE RecipeID = @RecipeID";
                        using (SqlCommand deleteIngredientsCmd = new SqlCommand(deleteIngredientsQuery, connection, transaction))
                        {
                            deleteIngredientsCmd.Parameters.AddWithValue("@RecipeID", recipeID);
                            await deleteIngredientsCmd.ExecuteNonQueryAsync();
                        }

                        // Then, delete the recipe itself
                        string deleteRecipeQuery = "DELETE FROM Recipes WHERE RecipeID = @RecipeID";
                        using (SqlCommand deleteRecipeCmd = new SqlCommand(deleteRecipeQuery, connection, transaction))
                        {
                            deleteRecipeCmd.Parameters.AddWithValue("@RecipeID", recipeID);
                            await deleteRecipeCmd.ExecuteNonQueryAsync();
                        }

                        transaction.Commit();
                        MessageBox.Show("Recipe deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Failed to delete the recipe. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Error(ex, "Error deleting the recipe.");
                    }
                }
            }
        }

        private void newProductBtn_Click(object sender, EventArgs e)
        {
            string productName = newProduct.Text;
            string productDescription = newProductDescription.Text;

            if (!string.IsNullOrEmpty(productName))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string insertProductQuery = "INSERT INTO Products (ProductName, ProductDescription) VALUES (@ProductName, @ProductDescription)";

                        using (SqlCommand cmd = new SqlCommand(insertProductQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@ProductName", productName);
                            cmd.Parameters.AddWithValue("@ProductDescription", productDescription);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Product Saved Successfully!");
                                newProduct.Text = ""; // Clear the TextBox
                                newProductDescription.Text = ""; // Clear the description TextBox
                                LoadProducts();
                            }
                            else
                            {
                                MessageBox.Show("Failed to save the product. Please try again.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    logger.Error(ex, "Error saving the product.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a product name.");
            }
        }



        private void productDeleteBtn_Click(object sender, EventArgs e)
        {
            if (ProductComboBox.SelectedValue != null)
            {
                int productId = (int)ProductComboBox.SelectedValue;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Delete associated records in RecipeIngredients first
                        string deleteRecipeIngredientsQuery = "DELETE FROM RecipeIngredients WHERE ProductID = @ProductID";
                        using (SqlCommand deleteRecipeIngredientsCmd = new SqlCommand(deleteRecipeIngredientsQuery, connection))
                        {
                            deleteRecipeIngredientsCmd.Parameters.AddWithValue("@ProductID", productId);
                            deleteRecipeIngredientsCmd.ExecuteNonQuery();
                        }

                        // Delete the product after associated records are deleted
                        string deleteProductQuery = "DELETE FROM Products WHERE ProductID = @ProductID";
                        SqlCommand cmd = new SqlCommand(deleteProductQuery, connection);
                        cmd.Parameters.AddWithValue("@ProductID", productId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product Deleted Successfully!");
                            ProductComboBox.DataSource = null; // Clear the combo box
                            LoadProducts();

                            // Repopulate the combo box to reflect the updated data
                            string selectProductsQuery = "SELECT ProductID, ProductName FROM Products";
                            SqlDataAdapter productAdapter = new SqlDataAdapter(selectProductsQuery, connection);
                            DataTable productTable = new DataTable();
                            productAdapter.Fill(productTable);
                            ProductComboBox.DataSource = productTable;
                            ProductComboBox.DisplayMember = "ProductName";
                            ProductComboBox.ValueMember = "ProductID";
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the product. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    logger.Error(ex, "Error deleting the product.");
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string selectCategoriesQuery = "SELECT CategoryID, CategoryName FROM Categories";
                    SqlDataAdapter categoryAdapter = new SqlDataAdapter(selectCategoriesQuery, connection);
                    DataTable categoryTable = new DataTable();
                    categoryAdapter.Fill(categoryTable);
                    comboBoxCategory.DataSource = categoryTable;
                    comboBoxCategory.DisplayMember = "CategoryName";
                    comboBoxCategory.ValueMember = "CategoryID";
                }

                // Populate the product combo box
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string selectProductsQuery = "SELECT ProductID, ProductName FROM Products";
                    SqlDataAdapter productAdapter = new SqlDataAdapter(selectProductsQuery, connection);
                    DataTable productTable = new DataTable();
                    productAdapter.Fill(productTable);
                    ProductComboBox.DataSource = productTable;
                    ProductComboBox.DisplayMember = "ProductName";
                    ProductComboBox.ValueMember = "ProductID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                logger.Error(ex, "Error loading categories and products.");
            }
        }

        private void newCategoryBtn_Click(object sender, EventArgs e)
        {
            string categoryName = newCategory.Text; // Get the category name from the TextBox

            if (!string.IsNullOrEmpty(categoryName))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string insertCategoryQuery = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";

                        using (SqlCommand cmd = new SqlCommand(insertCategoryQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Category Saved Successfully!");
                                newCategory.Text = ""; // Clear the TextBox
                                LoadCategories();
                            }
                            else
                            {
                                MessageBox.Show("Failed to save the category.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    logger.Error(ex, "Error saving a category.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a category name.");
            }
        }

        private void categoryDeleteBtn_Click(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedValue != null)
            {
                int categoryId = (int)comboBoxCategory.SelectedValue;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Check for related recipes and recipe ingredients
                        string checkRecipesQuery = "SELECT COUNT(*) FROM Recipes WHERE CategoryID = @CategoryID";
                        SqlCommand checkRecipesCmd = new SqlCommand(checkRecipesQuery, connection);
                        checkRecipesCmd.Parameters.AddWithValue("@CategoryID", categoryId);
                        int recipeCount = (int)checkRecipesCmd.ExecuteScalar();

                        string checkRecipeIngredientsQuery = "SELECT COUNT(*) FROM RecipeIngredients ri JOIN Recipes r ON ri.RecipeID = r.RecipeID WHERE r.CategoryID = @CategoryID";
                        SqlCommand checkRecipeIngredientsCmd = new SqlCommand(checkRecipeIngredientsQuery, connection);
                        checkRecipeIngredientsCmd.Parameters.AddWithValue("@CategoryID", categoryId);
                        int recipeIngredientCount = (int)checkRecipeIngredientsCmd.ExecuteScalar();

                        if (recipeCount > 0 || recipeIngredientCount > 0)
                        {
                            // Prompt the user for confirmation
                            DialogResult result = MessageBox.Show("This category is associated with recipes and/or recipe ingredients. Deleting it will also delete related records. Do you want to proceed?", "Confirmation", MessageBoxButtons.YesNo);
                            if (result == DialogResult.No)
                            {
                                return; // User canceled the deletion
                            }
                        }

                        // If we reach here, it means the user confirmed the deletion
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // First, delete related recipe ingredients
                                string deleteRecipeIngredientsQuery = "DELETE FROM RecipeIngredients WHERE RecipeID IN (SELECT RecipeID FROM Recipes WHERE CategoryID = @CategoryID)";
                                SqlCommand deleteRecipeIngredientsCmd = new SqlCommand(deleteRecipeIngredientsQuery, connection, transaction);
                                deleteRecipeIngredientsCmd.Parameters.AddWithValue("@CategoryID", categoryId);
                                deleteRecipeIngredientsCmd.ExecuteNonQuery();

                                // Then, delete related recipes
                                string deleteRecipesQuery = "DELETE FROM Recipes WHERE CategoryID = @CategoryID";
                                SqlCommand deleteRecipesCmd = new SqlCommand(deleteRecipesQuery, connection, transaction);
                                deleteRecipesCmd.Parameters.AddWithValue("@CategoryID", categoryId);
                                deleteRecipesCmd.ExecuteNonQuery();

                                // Finally, delete the category
                                string deleteCategoryQuery = "DELETE FROM Categories WHERE CategoryID = @CategoryID";
                                SqlCommand deleteCategoryCmd = new SqlCommand(deleteCategoryQuery, connection, transaction);
                                deleteCategoryCmd.Parameters.AddWithValue("@CategoryID", categoryId);

                                int rowsAffected = deleteCategoryCmd.ExecuteNonQuery();

                                transaction.Commit(); // Commit the transaction

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Category and related data Deleted Successfully!");
                                    comboBoxCategory.DataSource = null; // Clear the combo box
                                    LoadDataAsync();
                                    LoadCategories();
                                    // Repopulate the combo box to reflect the updated data
                                    string selectCategoriesQuery = "SELECT CategoryID, CategoryName FROM Categories";
                                    SqlDataAdapter categoryAdapter = new SqlDataAdapter(selectCategoriesQuery, connection);
                                    DataTable categoryTable = new DataTable();
                                    categoryAdapter.Fill(categoryTable);
                                    comboBoxCategory.DataSource = categoryTable;
                                    comboBoxCategory.DisplayMember = "CategoryName";
                                    comboBoxCategory.ValueMember = "CategoryID";
                                }
                                else
                                {
                                    MessageBox.Show("Failed to delete the category.");
                                }
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback(); // Rollback the transaction
                                MessageBox.Show("Failed to delete the category. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                logger.Error(ex, "Error deleting the category and related data.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                        logger.Error(ex, "Error while attempting to delete the category.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a category to delete.");
            }
        }

        private void deleteIngredient_Click(object sender, EventArgs e)
        {
            if (dataGridViewIngredients.Rows.Count > 0)
            {
                int lastIndex = dataGridViewIngredients.Rows.Count - 1; // Get the index of the last row
                dataGridViewIngredients.Rows.RemoveAt(lastIndex); // Remove the last row
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                // Perform autocomplete search when there is input
                PerformAutocompleteSearch(searchText);
            }
            else
            {
                // Reload all recipes when the search text is empty
                LoadDataAsync();
            }
        }
        private async void PerformAutocompleteSearch(string searchText)
        {
            try
            {
                List<Recipe> searchResults = await SearchRecipesInDatabaseAsync(searchText);

                // Clear existing user controls in the FlowLayoutPanel.
                flowLayoutPanel1.Controls.Clear();

                foreach (Recipe data in searchResults)
                {
                    RecipeUserControl recipeUserControl = new RecipeUserControl(this, data, false);
                    recipeUserControl.SetImage(data.ImagePath);
                    recipeUserControl.SetTitle(data.Title);
                    flowLayoutPanel1.Controls.Add(recipeUserControl);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions by showing a user-friendly message and logging the error.
                string errorMessage = "An error occurred during autocomplete search.";
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Error(ex, errorMessage);
            }
        }
        private async Task<List<Recipe>> SearchRecipesInDatabaseAsync(string searchText)
        {
            List<Recipe> searchResults = new List<Recipe>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // SQL query to select recipes based on title and category
                    string sqlQuery = "SELECT r.RecipeID, r.Title, r.ImagePath, r.CategoryID " +
                                      "FROM Recipes r " +
                                      "JOIN Categories c ON r.CategoryID = c.CategoryID " +
                                      "WHERE r.Title LIKE @searchText OR c.CategoryName LIKE @searchText";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                int recipeID = reader.GetInt32(0);
                                string title = reader.GetString(1);
                                string imagePath = reader.GetString(2);
                                int categoryID = reader.GetInt32(3);

                                Recipe recipe = new Recipe(recipeID, title, string.Empty, categoryID, "", imagePath, new List<RecipeIngredients>());
                                searchResults.Add(recipe);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions by showing a user-friendly message and logging the error.
                string errorMessage = "An error occurred during recipe search.";
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Error(ex, errorMessage);
            }

            return searchResults;
        }


    }
}
