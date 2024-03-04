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
            loginBtn = new Button();
            usernameBox = new TextBox();
            passwordBox = new TextBox();
            usernameLabel = new Label();
            passwordLabel = new Label();
            registerBtn = new Button();
            SuspendLayout();
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(329, 317);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(105, 45);
            loginBtn.TabIndex = 0;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // usernameBox
            // 
            usernameBox.Location = new Point(329, 212);
            usernameBox.Name = "usernameBox";
            usernameBox.Size = new Size(151, 23);
            usernameBox.TabIndex = 1;
            // 
            // passwordBox
            // 
            passwordBox.Location = new Point(330, 243);
            passwordBox.Name = "passwordBox";
            passwordBox.PasswordChar = '*';
            passwordBox.Size = new Size(151, 23);
            passwordBox.TabIndex = 2;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(260, 215);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(63, 15);
            usernameLabel.TabIndex = 3;
            usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(260, 246);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(60, 15);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password:";
            // 
            // registerBtn
            // 
            registerBtn.Location = new Point(329, 377);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(105, 45);
            registerBtn.TabIndex = 5;
            registerBtn.Text = "Register";
            registerBtn.UseVisualStyleBackColor = true;
            registerBtn.Click += registerBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(registerBtn);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(passwordBox);
            Controls.Add(usernameBox);
            Controls.Add(loginBtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginBtn;
        private TextBox usernameBox;
        private TextBox passwordBox;
        private Label usernameLabel;
        private Label passwordLabel;
        private Button registerBtn;
    }
}
