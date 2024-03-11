namespace SqlLogin
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
            loginButton = new Button();
            loginLabel = new Label();
            loginUsernameLabel = new Label();
            loginUsernameBox = new TextBox();
            loginPasswordLabel = new Label();
            loginPasswordBox = new TextBox();
            splitContainer1 = new SplitContainer();
            createButton = new Label();
            panel1 = new Panel();
            closeButton = new Label();
            registerUsernameBox = new TextBox();
            registerLabel = new Label();
            registerPasswordBox = new TextBox();
            registerButton = new Button();
            emailLabel = new Label();
            registerUsernameLabel = new Label();
            emailBox = new TextBox();
            registerPasswordLabel = new Label();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.IndianRed;
            loginButton.Location = new Point(20, 224);
            loginButton.Margin = new Padding(3, 4, 3, 4);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(251, 43);
            loginButton.TabIndex = 0;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginBtn_Click;
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginLabel.ForeColor = SystemColors.ControlLightLight;
            loginLabel.Location = new Point(10, 27);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(114, 46);
            loginLabel.TabIndex = 24;
            loginLabel.Text = "Login.";
            loginLabel.Click += label4_Click;
            // 
            // loginUsernameLabel
            // 
            loginUsernameLabel.AutoSize = true;
            loginUsernameLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginUsernameLabel.ForeColor = SystemColors.ButtonHighlight;
            loginUsernameLabel.Location = new Point(20, 85);
            loginUsernameLabel.Name = "loginUsernameLabel";
            loginUsernameLabel.Size = new Size(78, 20);
            loginUsernameLabel.TabIndex = 16;
            loginUsernameLabel.Text = "Username";
            // 
            // loginUsernameBox
            // 
            loginUsernameBox.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginUsernameBox.Location = new Point(20, 109);
            loginUsernameBox.Margin = new Padding(3, 4, 3, 4);
            loginUsernameBox.Name = "loginUsernameBox";
            loginUsernameBox.Size = new Size(251, 34);
            loginUsernameBox.TabIndex = 17;
            loginUsernameBox.TextAlign = HorizontalAlignment.Center;
            // 
            // loginPasswordLabel
            // 
            loginPasswordLabel.AutoSize = true;
            loginPasswordLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginPasswordLabel.ForeColor = SystemColors.ButtonHighlight;
            loginPasswordLabel.Location = new Point(20, 155);
            loginPasswordLabel.Name = "loginPasswordLabel";
            loginPasswordLabel.Size = new Size(73, 20);
            loginPasswordLabel.TabIndex = 19;
            loginPasswordLabel.Text = "Password";
            // 
            // loginPasswordBox
            // 
            loginPasswordBox.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginPasswordBox.Location = new Point(20, 179);
            loginPasswordBox.Margin = new Padding(3, 4, 3, 4);
            loginPasswordBox.Name = "loginPasswordBox";
            loginPasswordBox.Size = new Size(251, 34);
            loginPasswordBox.TabIndex = 20;
            loginPasswordBox.TextAlign = HorizontalAlignment.Center;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(1, -3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.Gray;
            splitContainer1.Panel1.Controls.Add(createButton);
            splitContainer1.Panel1.Controls.Add(loginLabel);
            splitContainer1.Panel1.Controls.Add(loginPasswordLabel);
            splitContainer1.Panel1.Controls.Add(loginButton);
            splitContainer1.Panel1.Controls.Add(loginUsernameLabel);
            splitContainer1.Panel1.Controls.Add(loginPasswordBox);
            splitContainer1.Panel1.Controls.Add(loginUsernameBox);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(55, 55, 55);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(860, 528);
            splitContainer1.SplitterDistance = 286;
            splitContainer1.TabIndex = 25;
            // 
            // createButton
            // 
            createButton.AutoSize = true;
            createButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createButton.ForeColor = SystemColors.ButtonHighlight;
            createButton.Location = new Point(20, 282);
            createButton.Name = "createButton";
            createButton.Size = new Size(251, 20);
            createButton.TabIndex = 25;
            createButton.Text = "Don't have an account? Create one.";
            createButton.Click += label3_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(closeButton);
            panel1.Controls.Add(registerUsernameBox);
            panel1.Controls.Add(registerLabel);
            panel1.Controls.Add(registerPasswordBox);
            panel1.Controls.Add(registerButton);
            panel1.Controls.Add(emailLabel);
            panel1.Controls.Add(registerUsernameLabel);
            panel1.Controls.Add(emailBox);
            panel1.Controls.Add(registerPasswordLabel);
            panel1.Controls.Add(checkBox1);
            panel1.Location = new Point(17, 15);
            panel1.Name = "panel1";
            panel1.Size = new Size(379, 272);
            panel1.TabIndex = 17;
            // 
            // closeButton
            // 
            closeButton.AutoSize = true;
            closeButton.Font = new Font("Impact", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            closeButton.ForeColor = Color.IndianRed;
            closeButton.Location = new Point(342, 0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(37, 42);
            closeButton.TabIndex = 18;
            closeButton.Text = "<";
            closeButton.Click += label6_Click;
            // 
            // registerUsernameBox
            // 
            registerUsernameBox.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            registerUsernameBox.Location = new Point(13, 94);
            registerUsernameBox.Margin = new Padding(3, 4, 3, 4);
            registerUsernameBox.Name = "registerUsernameBox";
            registerUsernameBox.Size = new Size(159, 34);
            registerUsernameBox.TabIndex = 22;
            registerUsernameBox.TextAlign = HorizontalAlignment.Center;
            // 
            // registerLabel
            // 
            registerLabel.AutoSize = true;
            registerLabel.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            registerLabel.ForeColor = SystemColors.ControlLightLight;
            registerLabel.Location = new Point(13, 14);
            registerLabel.Name = "registerLabel";
            registerLabel.Size = new Size(306, 46);
            registerLabel.TabIndex = 15;
            registerLabel.Text = "Create an account.";
            registerLabel.Click += label5_Click;
            // 
            // registerPasswordBox
            // 
            registerPasswordBox.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            registerPasswordBox.Location = new Point(207, 94);
            registerPasswordBox.Margin = new Padding(3, 4, 3, 4);
            registerPasswordBox.Name = "registerPasswordBox";
            registerPasswordBox.Size = new Size(159, 34);
            registerPasswordBox.TabIndex = 24;
            registerPasswordBox.TextAlign = HorizontalAlignment.Center;
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.IndianRed;
            registerButton.FlatAppearance.BorderColor = Color.White;
            registerButton.FlatAppearance.BorderSize = 2;
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.Location = new Point(257, 209);
            registerButton.Margin = new Padding(3, 4, 3, 4);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(109, 43);
            registerButton.TabIndex = 8;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = false;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emailLabel.ForeColor = SystemColors.ButtonHighlight;
            emailLabel.Location = new Point(13, 132);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(46, 20);
            emailLabel.TabIndex = 11;
            emailLabel.Text = "Email";
            // 
            // registerUsernameLabel
            // 
            registerUsernameLabel.AutoSize = true;
            registerUsernameLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            registerUsernameLabel.ForeColor = SystemColors.ButtonHighlight;
            registerUsernameLabel.Location = new Point(13, 70);
            registerUsernameLabel.Name = "registerUsernameLabel";
            registerUsernameLabel.Size = new Size(78, 20);
            registerUsernameLabel.TabIndex = 21;
            registerUsernameLabel.Text = "Username";
            // 
            // emailBox
            // 
            emailBox.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emailBox.Location = new Point(13, 156);
            emailBox.Margin = new Padding(3, 4, 3, 4);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(353, 34);
            emailBox.TabIndex = 12;
            emailBox.TextAlign = HorizontalAlignment.Center;
            // 
            // registerPasswordLabel
            // 
            registerPasswordLabel.AutoSize = true;
            registerPasswordLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            registerPasswordLabel.ForeColor = SystemColors.ButtonHighlight;
            registerPasswordLabel.Location = new Point(207, 70);
            registerPasswordLabel.Name = "registerPasswordLabel";
            registerPasswordLabel.Size = new Size(73, 20);
            registerPasswordLabel.TabIndex = 23;
            registerPasswordLabel.Text = "Password";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = SystemColors.ControlLightLight;
            checkBox1.Location = new Point(13, 219);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(238, 24);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "I agree to sell my data to China";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 325);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button loginButton;
        private Label loginLabel;
        private Label loginUsernameLabel;
        private TextBox loginUsernameBox;
        private Label loginPasswordLabel;
        private TextBox loginPasswordBox;
        private SplitContainer splitContainer1;
        private Label createButton;
        private Panel panel1;
        private TextBox registerUsernameBox;
        private Label registerLabel;
        private TextBox registerPasswordBox;
        private Button registerButton;
        private Label emailLabel;
        private Label registerUsernameLabel;
        private TextBox emailBox;
        private Label registerPasswordLabel;
        private CheckBox checkBox1;
        private Label closeButton;
    }
}
