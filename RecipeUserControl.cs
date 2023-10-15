using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RecipeGenius
{
    public partial class RecipeUserControl : UserControl
    {
        private Form1 parentForm;
        private Form5 parenttForm;
        private Recipe recipe;
        private bool isAdmin;

        public RecipeUserControl(Form1 parentForm, Recipe recipe, bool isAdmin)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.recipe = recipe;
            this.isAdmin = isAdmin;
        }

        public RecipeUserControl(Form5 parenttForm, Recipe recipe, bool isAdmin)
        {
            InitializeComponent();
            this.parenttForm = parenttForm;
            this.recipe = recipe;
            this.isAdmin = isAdmin;
        }

        public void SetImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                pictureBox1.ImageLocation = imagePath; // Use ImageLocation for performance
            }
        }

        public void SetTitle(string title)
        {
            recipeTitle.Text = title;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {



            int recipeID = recipe.RecipeID;

            if (isAdmin)
            {
                parenttForm.Hide();
                // Admin user
                Form5 form5 = new Form5(recipeID);

                form5.OpenTabPage1();

                form5.Show();

            }
            else
            {
                parentForm.Hide();
                // Ordinary user
                Form2 form2 = new Form2(recipeID);
                form2.Show();
            }

        }

        private void recipeTitle_Click(object sender, EventArgs e)
        {

            int recipeID = recipe.RecipeID;

            if (isAdmin)
            {
                parenttForm.Hide();
                // Admin user
                Form5 form5 = new Form5(recipeID);

                form5.OpenTabPage1();

                form5.Show();

            }
            else
            {
                parentForm.Hide();
                // Ordinary user
                Form2 form2 = new Form2(recipeID);
                form2.Show();
            }

        }



    }
}
