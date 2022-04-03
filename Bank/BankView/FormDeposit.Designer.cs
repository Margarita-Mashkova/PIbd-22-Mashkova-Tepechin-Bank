namespace BankView
{
    partial class FormDeposit
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxDepositInterest = new System.Windows.Forms.TextBox();
            this.textBoxDepositName = new System.Windows.Forms.TextBox();
            this.labelPassport = new System.Windows.Forms.Label();
            this.labelDepositName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(292, 104);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(115, 31);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(152, 104);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(115, 31);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxDepositInterest
            // 
            this.textBoxDepositInterest.Location = new System.Drawing.Point(151, 55);
            this.textBoxDepositInterest.Name = "textBoxDepositInterest";
            this.textBoxDepositInterest.Size = new System.Drawing.Size(186, 23);
            this.textBoxDepositInterest.TabIndex = 12;
            // 
            // textBoxDepositName
            // 
            this.textBoxDepositName.Location = new System.Drawing.Point(151, 17);
            this.textBoxDepositName.Name = "textBoxDepositName";
            this.textBoxDepositName.Size = new System.Drawing.Size(265, 23);
            this.textBoxDepositName.TabIndex = 11;
            // 
            // labelPassport
            // 
            this.labelPassport.AutoSize = true;
            this.labelPassport.Location = new System.Drawing.Point(12, 58);
            this.labelPassport.Name = "labelPassport";
            this.labelPassport.Size = new System.Drawing.Size(115, 15);
            this.labelPassport.TabIndex = 10;
            this.labelPassport.Text = "Процент по вкладу:";
            // 
            // labelDepositName
            // 
            this.labelDepositName.AutoSize = true;
            this.labelDepositName.Location = new System.Drawing.Point(12, 20);
            this.labelDepositName.Name = "labelDepositName";
            this.labelDepositName.Size = new System.Drawing.Size(133, 15);
            this.labelDepositName.TabIndex = 9;
            this.labelDepositName.Text = "Наименование вклада:";
            // 
            // FormDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 148);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxDepositInterest);
            this.Controls.Add(this.textBoxDepositName);
            this.Controls.Add(this.labelPassport);
            this.Controls.Add(this.labelDepositName);
            this.Name = "FormDeposit";
            this.Text = "Вклад";
            this.Load += new System.EventHandler(this.FormDeposit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonCancel;
        private Button buttonSave;
        private TextBox textBoxDepositInterest;
        private TextBox textBoxDepositName;
        private Label labelPassport;
        private Label labelDepositName;
    }
}