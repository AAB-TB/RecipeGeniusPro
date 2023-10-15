namespace RecipeGenius
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer1 = new SplitContainer();
            productsBtn = new Button();
            aboutBtn = new Button();
            homeBtn = new Button();
            pictureBox1 = new PictureBox();
            suggestionsListBox = new ListBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            searchTextBox = new TextBox();
            label1 = new Label();
            adminloginBtn = new Button();
            PasswordtxtBox = new TextBox();
            usernametxtBox = new TextBox();
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
            splitContainer1.Panel1.Controls.Add(aboutBtn);
            splitContainer1.Panel1.Controls.Add(homeBtn);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ControlLightLight;
            splitContainer1.Panel2.Controls.Add(suggestionsListBox);
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel1);
            splitContainer1.Panel2.Controls.Add(searchTextBox);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(adminloginBtn);
            splitContainer1.Panel2.Controls.Add(PasswordtxtBox);
            splitContainer1.Panel2.Controls.Add(usernametxtBox);
            splitContainer1.Size = new Size(1469, 898);
            splitContainer1.SplitterDistance = 270;
            splitContainer1.TabIndex = 0;
            // 
            // productsBtn
            // 
            productsBtn.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            productsBtn.ForeColor = Color.DarkGreen;
            productsBtn.Location = new Point(12, 516);
            productsBtn.Name = "productsBtn";
            productsBtn.Size = new Size(227, 41);
            productsBtn.TabIndex = 4;
            productsBtn.Text = "Our products";
            productsBtn.UseVisualStyleBackColor = true;
            productsBtn.Click += productsBtn_Click;
            // 
            // aboutBtn
            // 
            aboutBtn.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            aboutBtn.ForeColor = Color.DarkGreen;
            aboutBtn.Location = new Point(12, 743);
            aboutBtn.Name = "aboutBtn";
            aboutBtn.Size = new Size(227, 41);
            aboutBtn.TabIndex = 2;
            aboutBtn.Text = "About Us";
            aboutBtn.UseVisualStyleBackColor = true;
            aboutBtn.Click += aboutBtn_Click;
            // 
            // homeBtn
            // 
            homeBtn.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            homeBtn.ForeColor = Color.DarkGreen;
            homeBtn.Location = new Point(12, 295);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(227, 41);
            homeBtn.TabIndex = 1;
            homeBtn.Text = "Home";
            homeBtn.UseVisualStyleBackColor = true;
            homeBtn.Click += homeBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(227, 195);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // suggestionsListBox
            // 
            suggestionsListBox.BackColor = SystemColors.GradientActiveCaption;
            suggestionsListBox.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            suggestionsListBox.ForeColor = Color.DarkGreen;
            suggestionsListBox.FormattingEnabled = true;
            suggestionsListBox.ItemHeight = 29;
            suggestionsListBox.Location = new Point(249, 210);
            suggestionsListBox.Name = "suggestionsListBox";
            suggestionsListBox.Size = new Size(598, 62);
            suggestionsListBox.TabIndex = 6;
            suggestionsListBox.Visible = false;
            suggestionsListBox.SelectedIndexChanged += suggestionsListBox_SelectedIndexChanged_1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(31, 320);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1131, 551);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // searchTextBox
            // 
            searchTextBox.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            searchTextBox.ForeColor = Color.DarkGreen;
            searchTextBox.Location = new Point(249, 169);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Find Your recipe";
            searchTextBox.Size = new Size(598, 38);
            searchTextBox.TabIndex = 4;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(42, 108);
            label1.Name = "label1";
            label1.Size = new Size(1026, 58);
            label1.TabIndex = 3;
            label1.Text = "Discover the finest meat, sea food, fresh sallads, soul-warming soups, and irresistible dessearts.\r\n\r\n";
            // 
            // adminloginBtn
            // 
            adminloginBtn.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            adminloginBtn.ForeColor = Color.DarkGreen;
            adminloginBtn.Location = new Point(813, 34);
            adminloginBtn.Name = "adminloginBtn";
            adminloginBtn.Size = new Size(227, 41);
            adminloginBtn.TabIndex = 2;
            adminloginBtn.Text = "Log in";
            adminloginBtn.UseVisualStyleBackColor = true;
            adminloginBtn.Click += adminloginBtn_Click;
            // 
            // PasswordtxtBox
            // 
            PasswordtxtBox.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            PasswordtxtBox.ForeColor = Color.DarkGreen;
            PasswordtxtBox.Location = new Point(424, 34);
            PasswordtxtBox.Name = "PasswordtxtBox";
            PasswordtxtBox.PasswordChar = '*';
            PasswordtxtBox.PlaceholderText = "Admin Password";
            PasswordtxtBox.Size = new Size(325, 38);
            PasswordtxtBox.TabIndex = 1;
            // 
            // usernametxtBox
            // 
            usernametxtBox.Font = new Font("Sylfaen", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            usernametxtBox.ForeColor = Color.DarkGreen;
            usernametxtBox.Location = new Point(65, 34);
            usernametxtBox.Name = "usernametxtBox";
            usernametxtBox.PlaceholderText = "Admin Name";
            usernametxtBox.Size = new Size(325, 38);
            usernametxtBox.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1469, 898);
            Controls.Add(splitContainer1);
            MaximizeBox = false;
            Name = "Form1";
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
        private Button aboutBtn;
        private TextBox usernametxtBox;
        private Label label1;
        private Button adminloginBtn;
        private TextBox PasswordtxtBox;
        private TextBox searchTextBox;
        private Button productsBtn;
        private FlowLayoutPanel flowLayoutPanel1;
        private ListBox suggestionsListBox;
    }
}