namespace RecipeGenius
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            splitContainer1 = new SplitContainer();
            aboutBtn = new Button();
            homeBtn = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            textBoxProductDetails = new TextBox();
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
            splitContainer1.Panel1.Controls.Add(aboutBtn);
            splitContainer1.Panel1.Controls.Add(homeBtn);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(textBoxProductDetails);
            splitContainer1.Size = new Size(1372, 898);
            splitContainer1.SplitterDistance = 274;
            splitContainer1.TabIndex = 0;
            // 
            // aboutBtn
            // 
            aboutBtn.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            aboutBtn.ForeColor = Color.DarkGreen;
            aboutBtn.Location = new Point(24, 675);
            aboutBtn.Name = "aboutBtn";
            aboutBtn.Size = new Size(227, 41);
            aboutBtn.TabIndex = 7;
            aboutBtn.Text = "About Us";
            aboutBtn.UseVisualStyleBackColor = true;
            aboutBtn.Click += aboutBtn_Click;
            // 
            // homeBtn
            // 
            homeBtn.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            homeBtn.ForeColor = Color.DarkGreen;
            homeBtn.Location = new Point(24, 384);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(227, 41);
            homeBtn.TabIndex = 6;
            homeBtn.Text = "Home";
            homeBtn.UseVisualStyleBackColor = true;
            homeBtn.Click += homeBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(24, 63);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(227, 195);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.WhiteSmoke;
            label1.Font = new Font("Sylfaen", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(316, 59);
            label1.Name = "label1";
            label1.Size = new Size(327, 44);
            label1.TabIndex = 15;
            label1.Text = "List Of our products";
            // 
            // textBoxProductDetails
            // 
            textBoxProductDetails.BackColor = Color.WhiteSmoke;
            textBoxProductDetails.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxProductDetails.ForeColor = Color.DarkGreen;
            textBoxProductDetails.Location = new Point(65, 104);
            textBoxProductDetails.Multiline = true;
            textBoxProductDetails.Name = "textBoxProductDetails";
            textBoxProductDetails.ScrollBars = ScrollBars.Vertical;
            textBoxProductDetails.Size = new Size(964, 736);
            textBoxProductDetails.TabIndex = 14;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1372, 898);
            Controls.Add(splitContainer1);
            Name = "Form4";
            Text = "Form4";
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
        private Button aboutBtn;
        private Button homeBtn;
        private PictureBox pictureBox1;
        private Label label1;
        private TextBox textBoxProductDetails;
    }
}