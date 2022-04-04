namespace BankView
{
    partial class FormLinkCurrency
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
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.checkedListBoxDeposits = new System.Windows.Forms.CheckedListBox();
            this.buttonLink = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Location = new System.Drawing.Point(27, 43);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(288, 23);
            this.comboBoxCurrency.TabIndex = 0;
            this.comboBoxCurrency.Text = "Выберите валюту";
            // 
            // checkedListBoxDeposits
            // 
            this.checkedListBoxDeposits.FormattingEnabled = true;
            this.checkedListBoxDeposits.Location = new System.Drawing.Point(27, 84);
            this.checkedListBoxDeposits.Name = "checkedListBoxDeposits";
            this.checkedListBoxDeposits.Size = new System.Drawing.Size(288, 94);
            this.checkedListBoxDeposits.TabIndex = 1;
            // 
            // buttonLink
            // 
            this.buttonLink.Location = new System.Drawing.Point(27, 205);
            this.buttonLink.Name = "buttonLink";
            this.buttonLink.Size = new System.Drawing.Size(75, 23);
            this.buttonLink.TabIndex = 2;
            this.buttonLink.Text = "Привязать";
            this.buttonLink.UseVisualStyleBackColor = true;
            this.buttonLink.Click += new System.EventHandler(this.buttonLink_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(240, 205);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Назад";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormLinkCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 240);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonLink);
            this.Controls.Add(this.checkedListBoxDeposits);
            this.Controls.Add(this.comboBoxCurrency);
            this.Name = "FormLinkCurrency";
            this.Text = "FormLinkCurrency";
            this.Load += new System.EventHandler(this.FormLinkCurrency_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox comboBoxCurrency;
        private CheckedListBox checkedListBoxDeposits;
        private Button buttonLink;
        private Button buttonCancel;
    }
}