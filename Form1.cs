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
                // Log detailed error information using NLog
                logger.Error(ex, "An error occurred in the LoadDataAsync method. Message: {0}", ex.Message);

                // Show a user-friendly error message
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private async Task<List<Recipe>> RetrieveDataFromDatabaseAsync()
        {
            List<Recipe> recipeDataList = new List<Recipe>();

            try
            {
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
            }
            catch (Exception ex)
            {
                // Log detailed error information using NLog
                logger.Error(ex, "An error occurred in the RetrieveDataFromDatabaseAsync method. Message: {0}", ex.Message);
                
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
                            logger.Error($"Login failed for username: {username}.");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-related exceptions separately
                MessageBox.Show("An SQL error occurred: " + sqlEx.Message);
                logger.Error(sqlEx, "SQL error occurred in adminloginBtn_Click. Username: {0}, Message: {1}", username, sqlEx.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions here
                MessageBox.Show("An error occurred: " + ex.Message);
                logger.Error(ex, "An error occurred in adminloginBtn_Click. Username: {0}, Message: {1}", username, ex.Message);
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

            try
            {
                // Implement autocomplete logic here
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    // Call a method to get and display autocomplete suggestions
                    DisplayAutocompleteSuggestions(searchText);
                }
                else
                {
                    LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                MessageBox.Show("An error occurred: " + ex.Message);
                logger.Error(ex, "An error occurred in searchTextBox_TextChanged. Message: {0}", ex.Message);
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
                // Log detailed error information using NLog
                logger.Error(ex, "An error occurred while displaying autocomplete suggestions for search text: {0}. Message: {1}", searchText, ex.Message);

                // Show a user-friendly error message
                MessageBox.Show("An error occurred while displaying autocomplete suggestions: " + ex.Message);
            }
        }



        private async Task<List<string>> GetAutocompleteSuggestionsAsync(string searchText)
        {
            List<string> suggestions = new List<string>();

            try
            {
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
            }
            catch (Exception ex)
            {
                // Log detailed error information using NLog
                logger.Error(ex, "An error occurred in GetAutocompleteSuggestionsAsync for search text: {0}. Message: {1}", searchText, ex.Message);

                // You can choose to re-throw the exception if needed
                throw;
            }

            return suggestions;
        }

        private async void PerformSearch(string selectedSuggestion)
        {
            try
            {
                List<Recipe> searchResults = await SearchRecipesAsync(selectedSuggestion);
                suggestionsListBox.Visible = false;
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
                // Log detailed error information using NLog
                logger.Error(ex, "An error occurred in PerformSearch for selected suggestion: {0}. Message: {1}", selectedSuggestion, ex.Message);

                // Show a user-friendly error message
                MessageBox.Show("An error occurred during the search: " + ex.Message);
            }
        }

        private async Task<List<Recipe>> SearchRecipesAsync(string searchText)
        {
            List<Recipe> searchResults = new List<Recipe>();

            try
            {
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
            }
            catch (Exception ex)
            {
                // Log detailed error information using NLog
                logger.Error(ex, "An error occurred in SearchRecipesAsync for search text: {0}. Message: {1}", searchText, ex.Message);

                // You can choose to re-throw the exception if needed
                throw;
            }

            return searchResults;
        }



        private void suggestionsListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (suggestionsListBox.SelectedIndex != -1)
                {
                    string selectedSuggestion = suggestionsListBox.SelectedItem.ToString();
                    // Set the selected suggestion as the text in the searchTextBox
                    searchTextBox.Text = selectedSuggestion;
                    // Perform the search based on the selected suggestion
                    PerformSearch(selectedSuggestion);

                    // Explicitly hide the suggestionsListBox
                    suggestionsListBox.Visible = false;
                }
            }
            catch (Exception ex)
            {
                // Log detailed error information using NLog
                logger.Error(ex, "An error occurred in suggestionsListBox_SelectedIndexChanged_1. Message: {0}", ex.Message);

                // Show a user-friendly error message
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
    }

}