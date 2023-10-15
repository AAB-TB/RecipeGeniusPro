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

namespace RecipeGenius
{
    public partial class Form4 : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        string connectionString = "Data Source=Alvin-AB\\SQLEXPRESS;Initial Catalog=RecipeGenius;Integrated Security=True";
        public Form4()
        {

            InitializeComponent();
            LoadProductsDetails();
        }


        private void LoadProductsDetails()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to select data from the Products table
                    string query = "SELECT ProductID, ProductName, ProductDescription FROM Products";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Initialize a StringBuilder to build the product details
                            StringBuilder productDetails = new StringBuilder();

                            while (reader.Read())
                            {
                                // Append each product's details to the StringBuilder
                                productDetails.AppendLine($"Product ID: {reader["ProductID"]}");
                                productDetails.AppendLine($"Name: {reader["ProductName"]}");
                                productDetails.AppendLine($"Description: {reader["ProductDescription"]}");
                                productDetails.AppendLine("------------------------------");
                            }

                            // Set the TextBox text to the built product details
                            textBoxProductDetails.Text = productDetails.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions
                logger.Error(ex, "Error while loading products from the database");
                MessageBox.Show("An error occurred while loading products. Please check the logs for details.");
            }
        }















































        private void homeBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
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
