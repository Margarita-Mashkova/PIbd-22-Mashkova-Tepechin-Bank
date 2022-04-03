namespace BankView
{
    partial class FormManagerAuthorization
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
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelAuth = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(45, 69);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(41, 15);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Логин";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(45, 111);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(49, 15);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Пароль";
            // 
            // labelAuth
            // 
            this.labelAuth.AutoSize = true;
            this.labelAuth.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAuth.Location = new System.Drawing.Point(191, 9);
            this.labelAuth.Name = "labelAuth";
            this.labelAuth.Size = new System.Drawing.Size(125, 25);
            this.labelAuth.TabIndex = 2;
            this.labelAuth.Text = "Авторизация";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(151, 67);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(223, 23);
            this.textBoxLogin.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(150, 110);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(224, 23);
            this.textBoxPassword.TabIndex = 4;
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.Location = new System.Drawing.Point(45, 168);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(130, 29);
            this.buttonLogIn.TabIndex = 5;
            this.buttonLogIn.Text = "Войти";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(320, 168);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(130, 29);
            this.buttonRegister.TabIndex = 6;
            this.buttonRegister.Text = "Зарегистрироваться";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // FormAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 232);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelAuth);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Name = "FormAuthorization";
            this.Text = "FormAuthorization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelLogin;
        private Label labelPassword;
        private Label labelAuth;
        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Button buttonLogIn;
        private Button buttonRegister;
    }
}