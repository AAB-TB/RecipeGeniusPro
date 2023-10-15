namespace RecipeGenius
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            splitContainer1 = new SplitContainer();
            productsBtn = new Button();
            aboutBtn = new Button();
            pictureBox2 = new PictureBox();
            homeBtn = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cookingTimeBox = new TextBox();
            IngredientsBox = new TextBox();
            descriptionbox = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(productsBtn);
            splitContainer1.Panel1.Controls.Add(aboutBtn);
            splitContainer1.Panel1.Controls.Add(pictureBox2);
            splitContainer1.Panel1.Controls.Add(homeBtn);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(cookingTimeBox);
            splitContainer1.Panel2.Controls.Add(IngredientsBox);
            splitContainer1.Panel2.Controls.Add(descriptionbox);
            splitContainer1.Panel2.Controls.Add(pictureBox1);
            splitContainer1.Size = new Size(1469, 898);
            splitContainer1.SplitterDistance = 282;
            splitContainer1.TabIndex = 0;
            // 
            // productsBtn
            // 
            productsBtn.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            productsBtn.ForeColor = Color.DarkGreen;
            productsBtn.Location = new Point(19, 546);
            productsBtn.Name = "productsBtn";
            productsBtn.Size = new Size(227, 41);
            productsBtn.TabIndex = 16;
            productsBtn.Text = "Our products";
            productsBtn.UseVisualStyleBackColor = true;
            productsBtn.Click += productsBtn_Click;
            // 
            // aboutBtn
            // 
            aboutBtn.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            aboutBtn.ForeColor = Color.DarkGreen;
            aboutBtn.Location = new Point(19, 791);
            aboutBtn.Name = "aboutBtn";
            aboutBtn.Size = new Size(227, 41);
            aboutBtn.TabIndex = 15;
            aboutBtn.Text = "About Us";
            aboutBtn.UseVisualStyleBackColor = true;
            aboutBtn.Click += aboutBtn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Location = new Point(12, 29);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(234, 195);
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            // 
            // homeBtn
            // 
            homeBtn.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            homeBtn.ForeColor = Color.DarkGreen;
            homeBtn.Location = new Point(19, 325);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(227, 41);
            homeBtn.TabIndex = 13;
            homeBtn.Text = "Home";
            homeBtn.UseVisualStyleBackColor = true;
            homeBtn.Click += homeBtn_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.DarkGreen;
            label3.Location = new Point(25, 512);
            label3.Name = "label3";
            label3.Size = new Size(134, 29);
            label3.TabIndex = 15;
            label3.Text = "Ingredients";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DarkGreen;
            label2.Location = new Point(25, 77);
            label2.Name = "label2";
            label2.Size = new Size(141, 29);
            label2.TabIndex = 14;
            label2.Text = "Instructions";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.WhiteSmoke;
            label1.Font = new Font("Sylfaen", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(165, 29);
            label1.Name = "label1";
            label1.Size = new Size(99, 39);
            label1.TabIndex = 12;
            label1.Text = "label1";
            // 
            // cookingTimeBox
            // 
            cookingTimeBox.BackColor = Color.WhiteSmoke;
            cookingTimeBox.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            cookingTimeBox.ForeColor = Color.DarkGreen;
            cookingTimeBox.Location = new Point(651, 41);
            cookingTimeBox.Multiline = true;
            cookingTimeBox.Name = "cookingTimeBox";
            cookingTimeBox.ReadOnly = true;
            cookingTimeBox.Size = new Size(186, 34);
            cookingTimeBox.TabIndex = 11;
            cookingTimeBox.TabStop = false;
            // 
            // IngredientsBox
            // 
            IngredientsBox.BackColor = Color.WhiteSmoke;
            IngredientsBox.BorderStyle = BorderStyle.None;
            IngredientsBox.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            IngredientsBox.ForeColor = Color.DarkGreen;
            IngredientsBox.Location = new Point(25, 540);
            IngredientsBox.Multiline = true;
            IngredientsBox.Name = "IngredientsBox";
            IngredientsBox.ReadOnly = true;
            IngredientsBox.ScrollBars = ScrollBars.Vertical;
            IngredientsBox.Size = new Size(607, 346);
            IngredientsBox.TabIndex = 10;
            IngredientsBox.TabStop = false;
            // 
            // descriptionbox
            // 
            descriptionbox.BackColor = Color.WhiteSmoke;
            descriptionbox.BorderStyle = BorderStyle.None;
            descriptionbox.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            descriptionbox.ForeColor = Color.DarkGreen;
            descriptionbox.Location = new Point(25, 105);
            descriptionbox.Multiline = true;
            descriptionbox.Name = "descriptionbox";
            descriptionbox.ReadOnly = true;
            descriptionbox.ScrollBars = ScrollBars.Vertical;
            descriptionbox.Size = new Size(607, 404);
            descriptionbox.TabIndex = 9;
            descriptionbox.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(651, 77);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(505, 809);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1469, 898);
            Controls.Add(splitContainer1);
            ForeColor = Color.DarkGreen;
            MaximizeBox = false;
            Name = "Form2";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button homeBtn;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox cookingTimeBox;
        private TextBox IngredientsBox;
        private TextBox descriptionbox;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button aboutBtn;
        private Button productsBtn;
    }
}