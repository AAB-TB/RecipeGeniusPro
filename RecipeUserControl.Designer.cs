namespace RecipeGenius
{
    partial class RecipeUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            recipeTitle = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(15, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(226, 242);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // recipeTitle
            // 
            recipeTitle.BackColor = Color.White;
            recipeTitle.BorderStyle = BorderStyle.None;
            recipeTitle.Font = new Font("Algerian", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            recipeTitle.ForeColor = Color.DarkGreen;
            recipeTitle.Location = new Point(15, 237);
            recipeTitle.Multiline = true;
            recipeTitle.Name = "recipeTitle";
            recipeTitle.ReadOnly = true;
            recipeTitle.Size = new Size(226, 61);
            recipeTitle.TabIndex = 1;
            recipeTitle.Click += recipeTitle_Click;
            // 
            // RecipeUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(recipeTitle);
            Controls.Add(pictureBox1);
            Name = "RecipeUserControl";
            Size = new Size(255, 298);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox recipeTitle;
    }
}
