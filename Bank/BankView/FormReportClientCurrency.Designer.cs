namespace BankView
{
    partial class FormReportClientCurrency
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
            this.checkedListBoxClients = new System.Windows.Forms.CheckedListBox();
            this.buttonWord = new System.Windows.Forms.Button();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxClients
            // 
            this.checkedListBoxClients.FormattingEnabled = true;
            this.checkedListBoxClients.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxClients.Name = "checkedListBoxClients";
            this.checkedListBoxClients.Size = new System.Drawing.Size(769, 292);
            this.checkedListBoxClients.TabIndex = 0;
            // 
            // buttonWord
            // 
            this.buttonWord.Location = new System.Drawing.Point(45, 319);
            this.buttonWord.Name = "buttonWord";
            this.buttonWord.Size = new System.Drawing.Size(190, 30);
            this.buttonWord.TabIndex = 1;
            this.buttonWord.Text = "Сохранить в Word";
            this.buttonWord.UseVisualStyleBackColor = true;
            this.buttonWord.Click += new System.EventHandler(this.buttonWord_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.Location = new System.Drawing.Point(274, 319);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(190, 30);
            this.buttonExcel.TabIndex = 2;
            this.buttonExcel.Text = "Сохранить в Excel";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(591, 319);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(155, 30);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormReportClientCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 369);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.buttonWord);
            this.Controls.Add(this.checkedListBoxClients);
            this.Name = "FormReportClientCurrency";
            this.Text = "Получение списка валют";
            this.Load += new System.EventHandler(this.FormReportClientCurrency_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CheckedListBox checkedListBoxClients;
        private Button buttonWord;
        private Button buttonExcel;
        private Button buttonCancel;
    }
}