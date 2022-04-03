namespace BankView
{
    partial class FormLoanProgramCurrency
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
            this.labelName = new System.Windows.Forms.Label();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 26);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(48, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Валюта";
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Location = new System.Drawing.Point(117, 23);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(208, 23);
            this.comboBoxCurrency.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 70);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(250, 70);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(89, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Назад";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormLoanProgramCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 105);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxCurrency);
            this.Controls.Add(this.labelName);
            this.Name = "FormLoanProgramCurrency";
            this.Text = "FormLoanProgramCurrency";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelName;
        private ComboBox comboBoxCurrency;
        private Button buttonSave;
        private Button buttonCancel;
    }
}