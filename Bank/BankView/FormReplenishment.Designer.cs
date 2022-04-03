namespace BankView
{
    partial class FormReplenishment
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
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelDeposit = new System.Windows.Forms.Label();
            this.comboBoxDeposit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(301, 106);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(115, 31);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(161, 106);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(115, 31);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(151, 21);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(265, 23);
            this.textBoxAmount.TabIndex = 16;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(12, 24);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(119, 15);
            this.labelAmount.TabIndex = 15;
            this.labelAmount.Text = "Сумма пополнения:";
            // 
            // labelDeposit
            // 
            this.labelDeposit.AutoSize = true;
            this.labelDeposit.Location = new System.Drawing.Point(12, 65);
            this.labelDeposit.Name = "labelDeposit";
            this.labelDeposit.Size = new System.Drawing.Size(42, 15);
            this.labelDeposit.TabIndex = 19;
            this.labelDeposit.Text = "Вклад:";
            // 
            // comboBoxDeposit
            // 
            this.comboBoxDeposit.FormattingEnabled = true;
            this.comboBoxDeposit.Location = new System.Drawing.Point(151, 57);
            this.comboBoxDeposit.Name = "comboBoxDeposit";
            this.comboBoxDeposit.Size = new System.Drawing.Size(265, 23);
            this.comboBoxDeposit.TabIndex = 20;
            // 
            // FormReplenishment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 153);
            this.Controls.Add(this.comboBoxDeposit);
            this.Controls.Add(this.labelDeposit);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.labelAmount);
            this.Name = "FormReplenishment";
            this.Text = "Пополнение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonCancel;
        private Button buttonSave;
        private TextBox textBoxAmount;
        private Label labelAmount;
        private Label labelDeposit;
        private ComboBox comboBoxDeposit;
    }
}