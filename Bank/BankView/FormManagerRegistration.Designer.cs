namespace BankView
{
    partial class FormManagerRegistration
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
            this.buttonRegister = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelReg = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelFIO = new System.Windows.Forms.Label();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(263, 240);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(223, 29);
            this.buttonRegister.TabIndex = 13;
            this.buttonRegister.Text = "Зарегистрироваться";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(262, 136);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(224, 23);
            this.textBoxPassword.TabIndex = 11;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(263, 93);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(223, 23);
            this.textBoxLogin.TabIndex = 10;
            // 
            // labelReg
            // 
            this.labelReg.AutoSize = true;
            this.labelReg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelReg.Location = new System.Drawing.Point(303, 35);
            this.labelReg.Name = "labelReg";
            this.labelReg.Size = new System.Drawing.Size(121, 25);
            this.labelReg.TabIndex = 9;
            this.labelReg.Text = "Регистрация";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(157, 137);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(49, 15);
            this.labelPassword.TabIndex = 8;
            this.labelPassword.Text = "Пароль";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(157, 95);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(41, 15);
            this.labelLogin.TabIndex = 7;
            this.labelLogin.Text = "Логин";
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(160, 183);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(34, 15);
            this.labelFIO.TabIndex = 14;
            this.labelFIO.Text = "ФИО";
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(262, 180);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(224, 23);
            this.textBoxFIO.TabIndex = 15;
            // 
            // FormRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 318);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.labelFIO);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelReg);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Name = "FormRegistration";
            this.Text = "FormRegistration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonRegister;
        private TextBox textBoxPassword;
        private TextBox textBoxLogin;
        private Label labelReg;
        private Label labelPassword;
        private Label labelLogin;
        private Label labelFIO;
        private TextBox textBoxFIO;
    }
}