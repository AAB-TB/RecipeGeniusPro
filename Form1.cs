using System;
using NLog;
using System.Data.SqlClient;

namespace RecipeGenius
{
    public partial class Form1 : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        string connectionString = "Data Source=Alvin-AB\\SQLEXPRESS;Initial Catalog=RecipeGenius;Integrated Security=True";





        public Form1()
        {
            InitializeComponent();
            LoadDataAsync();

        }


        private async Task LoadDataAsync()
        {
            try
            {
                List<Recipe> recipeDataList = await RetrieveDataFromDatabaseAsync();

                // Clear existing user controls in the FlowLayoutPanel.
                flowLayoutPanel1.Controls.Clear();

                foreach (Recipe data in recipeDataList)
                {
                    RecipeUserControl recipeUserControl = new RecipeUserControl(this, data, false);
                    recipeUserControl.SetImage(data.ImagePath);
                    recipeUserControl.SetTitle(data.Title);
                    flowLayoutPanel1.Controls.Add(recipeUserControl);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                MessageBox.Show("An error occurred: " + ex.Message);
                logger.Error(ex, "An error occurred.");
            }
        }

        private async Task<List<Recipe>> RetrieveDataFromDatabaseAsync()
        {
            List<Recipe> recipeDataList = new List<Recipe>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the database connection
                await connection.OpenAsync();

                // SQL query to select image and title of recipes
                string sqlQuery = "SELECT r.RecipeID, r.Title, r.ImagePath, r.CategoryID " +
                                  "FROM Recipes r";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        int recipeID = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string imagePath = reader.GetString(2);
                        int categoryID = reader.GetInt32(3);

                        // Create a Recipe object and add it to the list
                        Recipe recipe = new Recipe(recipeID, title, string.Empty, categoryID, "", imagePath, new List<RecipeIngredients>());
                        recipeDataList.Add(recipe);
                    }
                }
            }

            return recipeDataList;
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void adminloginBtn_Click(object sender, EventArgs e)
        {
            string username = usernametxtBox.Text;
            string password = PasswordtxtBox.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT IsAdmin FROM Users WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        var result = command.ExecuteScalar();

                        if (result != null && (bool)result)
                        {
                            // User is an admin
                            Form5 form5 = new Form5();
                            form5.Show();
                            this.Hide();

                            // Clear the textboxes
                            usernametxtBox.Text = "";
                            PasswordtxtBox.Text = "";
                        }
                        else
                        {
                            // User is not an admin or login failed
                            MessageBox.Show("Login failed. Please check your credentials.");
                            logger.Error("Login failed for username: " + username);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                MessageBox.Show("An error occurred: " + ex.Message);
                logger.Error(ex, "An error occurred.");
            }



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

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text;

            // Implement autocomplete logic here
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                // Call a method to get and display autocomplete suggestions
                DisplayAutocompleteSuggestions(searchText);
            }
            else
            {
                // If the search text is empty, hide the ListBox
                suggestionsListBox.Visible = false;
            }
        }

        private async void DisplayAutocompleteSuggestions(string searchText)
        {
            try
            {
                // Query the database for autocomplete suggestions
                List<string> suggestions = await GetAutocompleteSuggestionsAsync(searchText);

                // Clear the ListBox before adding new suggestions
                suggestionsListBox.Items.Clear();

                if (suggestions.Count > 0)
                {
                    // Add suggestions to the ListBox
                    suggestionsListBox.Items.AddRange(suggestions.ToArray());

                    // Show the ListBox below the search TextBox
                    suggestionsListBox.Location = new Point(searchTextBox.Location.X, searchTextBox.Location.Y + searchTextBox.Height);
                    suggestionsListBox.Visible = true;
                }
                else
                {
                    // If there are no suggestions, hide the ListBox
                    suggestionsListBox.Visible = false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                MessageBox.Show("An error occurred: " + ex.Message);
                logger.Error(ex, "An error occurred while displaying autocomplete suggestions.");
            }
        }



        private async Task<List<string>> GetAutocompleteSuggestionsAsync(string searchText)
        {
            List<string> suggestions = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();


                string sqlQuery = "SELECT r.Title, c.CategoryName " +
                          "FROM Recipes r " +
                          "JOIN Categories c ON r.CategoryID = c.CategoryID " +
                          "WHERE (r.Title LIKE @searchText + '%' OR c.CategoryName LIKE @searchText + '%')";


                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@searchText", searchText);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            suggestions.Add(reader.GetString(0)); // Add recipe titles
                            suggestions.Add(reader.GetString(1)); // Add category names
                        }
                    }
                }
            }

            return suggestions;
        }

        private void suggestionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suggestionsListBox.SelectedIndex != -1)
            {
                string selectedSuggestion = suggestionsListBox.SelectedItem.ToString();
                // Perform the search based on the selected suggestion
                PerformSearch(selectedSuggestion);
                // Clear the search text and hide the suggestions
                searchTextBox.Text = string.Empty;
                suggestionsListBox.Visible = false;
            }
        }
        private async void PerformSearch(string selectedSuggestion)
        {
            try
            {
                List<Recipe> searchResults = await SearchRecipesAsync(selectedSuggestion);

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
                // Handle exceptions here
                MessageBox.Show("An error occurred during the search: " + ex.Message);
                logger.Error(ex, "An error occurred during the search.");
            }
        }
        private async Task<List<Recipe>> SearchRecipesAsync(string searchText)
        {
            List<Recipe> searchResults = new List<Recipe>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // SQL query to search for recipes based on title and category
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

                            // Create a Recipe object and add it to the search results
                            Recipe recipe = new Recipe(recipeID, title, string.Empty, categoryID, "", imagePath, new List<RecipeIngredients>());
                            searchResults.Add(recipe);
                        }
                    }
                }
            }

            return searchResults;
        }

    }

}