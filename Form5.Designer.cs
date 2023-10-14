namespace RecipeGenius
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            splitContainer1 = new SplitContainer();
            btnAddIngredient = new Button();
            btnDeleteRecipe = new Button();
            updateBtn = new Button();
            btnSaveRecipe = new Button();
            homeBtn = new Button();
            pictureBox1 = new PictureBox();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            flowLayoutPanel1 = new FlowLayoutPanel();
            searchTextBox = new TextBox();
            tabPage1 = new TabPage();
            ingredientBtn = new Button();
            dataGridViewIngredients = new DataGridView();
            ProductList = new DataGridViewComboBoxColumn();
            QuantityBox = new DataGridViewTextBoxColumn();
            categoryComboBox = new ComboBox();
            txtCookingTime = new TextBox();
            txtRecipeInstructions = new TextBox();
            pictureBoxRecipe = new PictureBox();
            txtRecipeTitle = new TextBox();
            tabPage3 = new TabPage();
            groupBox2 = new GroupBox();
            categoryDeleteBtn = new Button();
            newCategory = new TextBox();
            comboBoxCategory = new ComboBox();
            newCategoryBtn = new Button();
            groupBox1 = new GroupBox();
            newProduct = new TextBox();
            newProductDescription = new TextBox();
            productDeleteBtn = new Button();
            newProductBtn = new Button();
            ProductComboBox = new ComboBox();
            openFileDialog1 = new OpenFileDialog();
            deleteIngredient = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngredients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecipe).BeginInit();
            tabPage3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.CornflowerBlue;
            splitContainer1.Panel1.Controls.Add(btnAddIngredient);
            splitContainer1.Panel1.Controls.Add(btnDeleteRecipe);
            splitContainer1.Panel1.Controls.Add(updateBtn);
            splitContainer1.Panel1.Controls.Add(btnSaveRecipe);
            splitContainer1.Panel1.Controls.Add(homeBtn);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.White;
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Size = new Size(1469, 898);
            splitContainer1.SplitterDistance = 295;
            splitContainer1.TabIndex = 0;
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.Location = new Point(0, 0);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(75, 23);
            btnAddIngredient.TabIndex = 0;
            // 
            // btnDeleteRecipe
            // 
            btnDeleteRecipe.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteRecipe.ForeColor = Color.DarkGreen;
            btnDeleteRecipe.Location = new Point(12, 674);
            btnDeleteRecipe.Name = "btnDeleteRecipe";
            btnDeleteRecipe.Size = new Size(248, 41);
            btnDeleteRecipe.TabIndex = 7;
            btnDeleteRecipe.Text = "Delete recipe";
            btnDeleteRecipe.UseVisualStyleBackColor = true;
            btnDeleteRecipe.Click += btnDeleteRecipe_Click;
            // 
            // updateBtn
            // 
            updateBtn.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            updateBtn.ForeColor = Color.DarkGreen;
            updateBtn.Location = new Point(12, 537);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(248, 41);
            updateBtn.TabIndex = 6;
            updateBtn.Text = "Update Recipe";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click_1;
            // 
            // btnSaveRecipe
            // 
            btnSaveRecipe.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnSaveRecipe.ForeColor = Color.DarkGreen;
            btnSaveRecipe.Location = new Point(12, 411);
            btnSaveRecipe.Name = "btnSaveRecipe";
            btnSaveRecipe.Size = new Size(248, 41);
            btnSaveRecipe.TabIndex = 5;
            btnSaveRecipe.Text = "Add New Recipe";
            btnSaveRecipe.UseVisualStyleBackColor = true;
            btnSaveRecipe.Click += btnSaveRecipe_Click;
            // 
            // homeBtn
            // 
            homeBtn.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            homeBtn.ForeColor = Color.DarkGreen;
            homeBtn.Location = new Point(12, 280);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(248, 41);
            homeBtn.TabIndex = 2;
            homeBtn.Text = "Home";
            homeBtn.UseVisualStyleBackColor = true;
            homeBtn.Click += homeBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(25, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(227, 195);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1170, 898);
            tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.AutoScroll = true;
            tabPage2.BackColor = Color.White;
            tabPage2.BorderStyle = BorderStyle.Fixed3D;
            tabPage2.Controls.Add(flowLayoutPanel1);
            tabPage2.Controls.Add(searchTextBox);
            tabPage2.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            tabPage2.ForeColor = Color.DarkGreen;
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1162, 862);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "View Recipes";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(23, 154);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1118, 698);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // searchTextBox
            // 
            searchTextBox.Font = new Font("Algerian", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            searchTextBox.ForeColor = Color.DarkGreen;
            searchTextBox.Location = new Point(282, 62);
            searchTextBox.Multiline = true;
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Find Your recipe";
            searchTextBox.Size = new Size(598, 59);
            searchTextBox.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.AutoScroll = true;
            tabPage1.BackColor = Color.White;
            tabPage1.BorderStyle = BorderStyle.Fixed3D;
            tabPage1.Controls.Add(deleteIngredient);
            tabPage1.Controls.Add(ingredientBtn);
            tabPage1.Controls.Add(dataGridViewIngredients);
            tabPage1.Controls.Add(categoryComboBox);
            tabPage1.Controls.Add(txtCookingTime);
            tabPage1.Controls.Add(txtRecipeInstructions);
            tabPage1.Controls.Add(pictureBoxRecipe);
            tabPage1.Controls.Add(txtRecipeTitle);
            tabPage1.Font = new Font("Algerian", 12F, FontStyle.Bold, GraphicsUnit.Point);
            tabPage1.ForeColor = Color.DarkGreen;
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1162, 862);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Add/Update Recipe";
            // 
            // ingredientBtn
            // 
            ingredientBtn.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            ingredientBtn.ForeColor = Color.DarkGreen;
            ingredientBtn.Location = new Point(545, 652);
            ingredientBtn.Name = "ingredientBtn";
            ingredientBtn.Size = new Size(227, 41);
            ingredientBtn.TabIndex = 12;
            ingredientBtn.Text = "Add";
            ingredientBtn.UseVisualStyleBackColor = true;
            ingredientBtn.Click += ingredientBtn_Click;
            // 
            // dataGridViewIngredients
            // 
            dataGridViewIngredients.AllowDrop = true;
            dataGridViewIngredients.AllowUserToAddRows = false;
            dataGridViewIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIngredients.Columns.AddRange(new DataGridViewColumn[] { ProductList, QuantityBox });
            dataGridViewIngredients.Location = new Point(545, 432);
            dataGridViewIngredients.Name = "dataGridViewIngredients";
            dataGridViewIngredients.RowHeadersWidth = 51;
            dataGridViewIngredients.RowTemplate.Height = 29;
            dataGridViewIngredients.Size = new Size(481, 188);
            dataGridViewIngredients.TabIndex = 22;
            // 
            // ProductList
            // 
            ProductList.HeaderText = "Product List";
            ProductList.MinimumWidth = 6;
            ProductList.Name = "ProductList";
            // 
            // QuantityBox
            // 
            QuantityBox.HeaderText = "Quantity";
            QuantityBox.MinimumWidth = 6;
            QuantityBox.Name = "QuantityBox";
            // 
            // categoryComboBox
            // 
            categoryComboBox.Font = new Font("Algerian", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            categoryComboBox.ForeColor = Color.DarkGreen;
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Location = new Point(718, 279);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(299, 38);
            categoryComboBox.TabIndex = 21;
            categoryComboBox.Text = "Category";
            // 
            // txtCookingTime
            // 
            txtCookingTime.BackColor = Color.White;
            txtCookingTime.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtCookingTime.ForeColor = Color.DarkOliveGreen;
            txtCookingTime.Location = new Point(26, 283);
            txtCookingTime.Multiline = true;
            txtCookingTime.Name = "txtCookingTime";
            txtCookingTime.PlaceholderText = "Cooking Time";
            txtCookingTime.Size = new Size(286, 40);
            txtCookingTime.TabIndex = 20;
            txtCookingTime.TabStop = false;
            // 
            // txtRecipeInstructions
            // 
            txtRecipeInstructions.BackColor = Color.White;
            txtRecipeInstructions.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtRecipeInstructions.ForeColor = Color.DarkOliveGreen;
            txtRecipeInstructions.Location = new Point(26, 377);
            txtRecipeInstructions.Multiline = true;
            txtRecipeInstructions.Name = "txtRecipeInstructions";
            txtRecipeInstructions.PlaceholderText = "Instructions";
            txtRecipeInstructions.Size = new Size(444, 457);
            txtRecipeInstructions.TabIndex = 19;
            txtRecipeInstructions.TabStop = false;
            // 
            // pictureBoxRecipe
            // 
            pictureBoxRecipe.BackgroundImage = (Image)resources.GetObject("pictureBoxRecipe.BackgroundImage");
            pictureBoxRecipe.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxRecipe.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxRecipe.Location = new Point(344, 92);
            pictureBoxRecipe.Name = "pictureBoxRecipe";
            pictureBoxRecipe.Size = new Size(342, 244);
            pictureBoxRecipe.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRecipe.TabIndex = 17;
            pictureBoxRecipe.TabStop = false;
            pictureBoxRecipe.Click += pictureBoxRecipe_Click;
            // 
            // txtRecipeTitle
            // 
            txtRecipeTitle.BackColor = Color.White;
            txtRecipeTitle.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtRecipeTitle.ForeColor = Color.DarkOliveGreen;
            txtRecipeTitle.Location = new Point(206, 16);
            txtRecipeTitle.Multiline = true;
            txtRecipeTitle.Name = "txtRecipeTitle";
            txtRecipeTitle.PlaceholderText = "recipe Title";
            txtRecipeTitle.Size = new Size(603, 58);
            txtRecipeTitle.TabIndex = 15;
            txtRecipeTitle.TabStop = false;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.White;
            tabPage3.BorderStyle = BorderStyle.Fixed3D;
            tabPage3.Controls.Add(groupBox2);
            tabPage3.Controls.Add(groupBox1);
            tabPage3.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            tabPage3.ForeColor = Color.DarkGreen;
            tabPage3.Location = new Point(4, 32);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1162, 862);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Product/category";
            tabPage3.Click += tabPage3_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(categoryDeleteBtn);
            groupBox2.Controls.Add(newCategory);
            groupBox2.Controls.Add(comboBoxCategory);
            groupBox2.Controls.Add(newCategoryBtn);
            groupBox2.Location = new Point(104, 323);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(641, 197);
            groupBox2.TabIndex = 27;
            groupBox2.TabStop = false;
            groupBox2.Text = "New Category";
            // 
            // categoryDeleteBtn
            // 
            categoryDeleteBtn.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            categoryDeleteBtn.ForeColor = Color.DarkGreen;
            categoryDeleteBtn.Location = new Point(428, 128);
            categoryDeleteBtn.Name = "categoryDeleteBtn";
            categoryDeleteBtn.Size = new Size(171, 41);
            categoryDeleteBtn.TabIndex = 29;
            categoryDeleteBtn.Text = "Delete";
            categoryDeleteBtn.UseVisualStyleBackColor = true;
            categoryDeleteBtn.Click += categoryDeleteBtn_Click;
            // 
            // newCategory
            // 
            newCategory.BackColor = Color.White;
            newCategory.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            newCategory.ForeColor = Color.DarkOliveGreen;
            newCategory.Location = new Point(19, 56);
            newCategory.Multiline = true;
            newCategory.Name = "newCategory";
            newCategory.PlaceholderText = "Enter new category";
            newCategory.Size = new Size(390, 40);
            newCategory.TabIndex = 22;
            newCategory.TabStop = false;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(19, 133);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(390, 33);
            comboBoxCategory.TabIndex = 28;
            // 
            // newCategoryBtn
            // 
            newCategoryBtn.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            newCategoryBtn.ForeColor = Color.DarkGreen;
            newCategoryBtn.Location = new Point(428, 56);
            newCategoryBtn.Name = "newCategoryBtn";
            newCategoryBtn.Size = new Size(171, 41);
            newCategoryBtn.TabIndex = 24;
            newCategoryBtn.Text = "Save";
            newCategoryBtn.UseVisualStyleBackColor = true;
            newCategoryBtn.Click += newCategoryBtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(newProduct);
            groupBox1.Controls.Add(newProductDescription);
            groupBox1.Controls.Add(productDeleteBtn);
            groupBox1.Controls.Add(newProductBtn);
            groupBox1.Controls.Add(ProductComboBox);
            groupBox1.Location = new Point(104, 42);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(641, 252);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "New Product";
            // 
            // newProduct
            // 
            newProduct.BackColor = Color.White;
            newProduct.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            newProduct.ForeColor = Color.DarkOliveGreen;
            newProduct.Location = new Point(6, 50);
            newProduct.Multiline = true;
            newProduct.Name = "newProduct";
            newProduct.PlaceholderText = "Enter new Product";
            newProduct.Size = new Size(403, 40);
            newProduct.TabIndex = 21;
            newProduct.TabStop = false;
            // 
            // newProductDescription
            // 
            newProductDescription.BackColor = Color.White;
            newProductDescription.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            newProductDescription.ForeColor = Color.DarkOliveGreen;
            newProductDescription.Location = new Point(6, 120);
            newProductDescription.Multiline = true;
            newProductDescription.Name = "newProductDescription";
            newProductDescription.PlaceholderText = "Product description";
            newProductDescription.Size = new Size(403, 40);
            newProductDescription.TabIndex = 25;
            newProductDescription.TabStop = false;
            // 
            // productDeleteBtn
            // 
            productDeleteBtn.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            productDeleteBtn.ForeColor = Color.DarkGreen;
            productDeleteBtn.Location = new Point(428, 186);
            productDeleteBtn.Name = "productDeleteBtn";
            productDeleteBtn.Size = new Size(171, 41);
            productDeleteBtn.TabIndex = 27;
            productDeleteBtn.Text = "Delete";
            productDeleteBtn.UseVisualStyleBackColor = true;
            productDeleteBtn.Click += productDeleteBtn_Click;
            // 
            // newProductBtn
            // 
            newProductBtn.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            newProductBtn.ForeColor = Color.DarkGreen;
            newProductBtn.Location = new Point(428, 78);
            newProductBtn.Name = "newProductBtn";
            newProductBtn.Size = new Size(171, 41);
            newProductBtn.TabIndex = 23;
            newProductBtn.Text = "Save";
            newProductBtn.UseVisualStyleBackColor = true;
            newProductBtn.Click += newProductBtn_Click;
            // 
            // ProductComboBox
            // 
            ProductComboBox.FormattingEnabled = true;
            ProductComboBox.Location = new Point(6, 194);
            ProductComboBox.Name = "ProductComboBox";
            ProductComboBox.Size = new Size(403, 33);
            ProductComboBox.TabIndex = 26;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // deleteIngredient
            // 
            deleteIngredient.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            deleteIngredient.ForeColor = Color.DarkGreen;
            deleteIngredient.Location = new Point(800, 652);
            deleteIngredient.Name = "deleteIngredient";
            deleteIngredient.Size = new Size(226, 41);
            deleteIngredient.TabIndex = 23;
            deleteIngredient.Text = "Delete";
            deleteIngredient.UseVisualStyleBackColor = true;
            deleteIngredient.Click += deleteIngredient_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1469, 898);
            Controls.Add(splitContainer1);
            Name = "Form5";
            Text = "Form5";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngredients).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecipe).EndInit();
            tabPage3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private PictureBox pictureBox1;
        private Button homeBtn;
        private Button btnSaveRecipe;
        private Button btnDeleteRecipe;
        private Button updateBtn;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TextBox searchTextBox;
        private TextBox txtRecipeInstructions;
        private PictureBox pictureBoxRecipe;
        private TextBox txtRecipeTitle;
        private ComboBox categoryComboBox;
        private TextBox txtCookingTime;
        private Button btnAddIngredient;
        private OpenFileDialog openFileDialog1;
        private DataGridView dataGridViewIngredients;
        private DataGridViewComboBoxColumn ProductList;
        private DataGridViewTextBoxColumn QuantityBox;
        private Button ingredientBtn;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button newCategoryBtn;
        private Button newProductBtn;
        private TextBox newCategory;
        private TextBox newProduct;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private TextBox newProductDescription;
        private Button categoryDeleteBtn;
        private ComboBox comboBoxCategory;
        private Button productDeleteBtn;
        private ComboBox ProductComboBox;
        private Button deleteIngredient;
    }
}