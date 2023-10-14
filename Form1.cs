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
                string sqlQuery = "SELECT r.RecipeID, r.Title, r.ImagePath " +
                                  "FROM Recipes r";

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
    }

}