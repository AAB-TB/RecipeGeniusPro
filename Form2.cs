using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using NLog;
using System.Reflection.Emit;

namespace RecipeGenius
{
    public partial class Form2 : Form
    {
        //Recipe selectedRecipe;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        string connectionString = "Data Source=ALVIN-AB\\SQLEXPRESS;Initial Catalog=RecipeGenius;Integrated Security=True";

        public Form2(int selectedRecipeID)
        {

            InitializeComponent();
            LoadRecipeDetails(selectedRecipeID);
        }

        private void LoadRecipeDetails(int selectedRecipeID)
        {
            // Retrieve the selected recipe details
            Recipe selectedRecipe = RetrieveRecipeDetailsFromDatabase(selectedRecipeID);

            // Check if a valid recipe was found
            if (selectedRecipe != null)
            {
                // Populate the UI controls with the retrieved data
                descriptionbox.Text = selectedRecipe.RecipeDescription; // Use RecipeDescription
                label1.Text = selectedRecipe.Title;
                // Concatenate the ingredients and quantities into a string
                StringBuilder ingredientsText = new StringBuilder();
                foreach (RecipeIngredients ingredient in selectedRecipe.RecipeIngredients)
                {
                    ingredientsText.AppendLine($"{ingredient.Quantity} - {GetProductName(ingredient.ProductID)}");
                }
                IngredientsBox.Text = ingredientsText.ToString();

                // Set the cooking time
                cookingTimeBox.Text = selectedRecipe.CookingTime; // Use CookingTime as string


                // Load the recipe image into the PictureBox
                pictureBox1.Image = System.Drawing.Image.FromFile(selectedRecipe.ImagePath);
            }
            else
            {
                // Handle the case where the selected recipe doesn't exist or an error occurred
                // You might want to display an error message or clear the UI controls.
            }
        }

        private Recipe RetrieveRecipeDetailsFromDatabase(int recipeID)
        {
            string query = @"
    SELECT
        r.RecipeID, r.Title, r.RecipeDescription, r.CategoryID, r.CookingTime, r.ImagePath,
        ri.RecipeIngredientID, ri.ProductID, ri.Quantity, p.ProductName
    FROM Recipes r
    LEFT JOIN RecipeIngredients ri ON r.RecipeID = ri.RecipeID
    LEFT JOIN Products p ON ri.ProductID = p.ProductID
    WHERE r.RecipeID = @RecipeID
    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RecipeID", recipeID);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Recipe recipe = null;

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (recipe == null)
                            {
                                int recipeId = reader.GetInt32(0);
                                string title = reader.GetString(1);
                                string description = reader.GetString(2);
                                int categoryID = reader.GetInt32(3);
                                string cookingTime = reader.IsDBNull(4) ? "N/A" : reader.GetString(4);
                                //string cookingTime = reader.GetString(4); // Store as string
                                string imagePath = reader.GetString(5);

                                recipe = new Recipe(recipeID, title, description, categoryID, cookingTime, imagePath, new List<RecipeIngredients>());
                            }
                            int recipeIngredientID = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                            //int recipeIngredientID = reader.GetInt32(6);
                            int productID = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                            string quantity = reader.IsDBNull(8) ? "N/A" : reader.GetString(8);
                            string productName = reader.IsDBNull(8) ? "N/A" : reader.GetString(9);

                            RecipeIngredients ingredient = new RecipeIngredients
                            {
                                RecipeIngredientID = recipeIngredientID,
                                RecipeID = recipeID,
                                ProductID = productID,
                                Quantity = quantity
                            };

                            recipe.RecipeIngredients.Add(ingredient);
                        }
                    }
                    else
                    {
                        // Handle the case where no matching recipe is found, e.g., display an error message or return null.
                        // You may want to log this situation for debugging.
                        logger.Error($"Recipe with RecipeID {recipeID} not found in the database.");
                    }

                    return recipe;
                }
            }

            // Handle any other errors here.
            return null;
        }

        private string GetProductName(int productID)
        {
            // string connectionString = "Your_Connection_String";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductName FROM Products WHERE ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productID);
                    connection.Open();

                    string productName = (string)command.ExecuteScalar();

                    return productName;
                }
            }

            // If the product is not found or an error occurs, return a default value or handle the error as needed.
            return "Product Not Found";
        }


        private void homeBtn_Click_1(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void productsBtn_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
    }
}
