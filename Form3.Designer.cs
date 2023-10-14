namespace RecipeGenius
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            splitContainer1 = new SplitContainer();
            homeBtn = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            textBox1 = new TextBox();
            productsBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(homeBtn);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.White;
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Size = new Size(1372, 898);
            splitContainer1.SplitterDistance = 273;
            splitContainer1.TabIndex = 0;
            // 
            // homeBtn
            // 
            homeBtn.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            homeBtn.ForeColor = Color.DarkGreen;
            homeBtn.Location = new Point(22, 296);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(227, 41);
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
            pictureBox1.Location = new Point(22, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(227, 195);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightSalmon;
            label1.Font = new Font("Algerian", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(321, 38);
            label1.Name = "label1";
            label1.Size = new Size(364, 31);
            label1.TabIndex = 13;
            label1.Text = "International Food AB";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.LightSalmon;
            textBox1.Font = new Font("Algerian", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            textBox1.ForeColor = Color.DarkGreen;
            textBox1.Location = new Point(70, 83);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(964, 736);
            textBox1.TabIndex = 0;
            textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // productsBtn
            // 
            productsBtn.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            productsBtn.ForeColor = Color.DarkGreen;
            productsBtn.Location = new Point(22, 529);
            productsBtn.Name = "productsBtn";
            productsBtn.Size = new Size(227, 41);
            productsBtn.TabIndex = 17;
            productsBtn.Text = "Our products";
            productsBtn.UseVisualStyleBackColor = true;
            productsBtn.Click += productsBtn_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1372, 898);
            Controls.Add(splitContainer1);
            Name = "Form3";
            Text = "Form3";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private PictureBox pictureBox1;
        private Button homeBtn;
        private TextBox textBox1;
        private Label label1;
        private Button productsBtn;
    }
}