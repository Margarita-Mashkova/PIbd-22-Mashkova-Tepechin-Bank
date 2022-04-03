namespace BankView
{
    partial class FormClientLoanProgram
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
            this.labelLoanProgram = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.comboBoxLoanProgram = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelLoanProgram
            // 
            this.labelLoanProgram.AutoSize = true;
            this.labelLoanProgram.Location = new System.Drawing.Point(12, 22);
            this.labelLoanProgram.Name = "labelLoanProgram";
            this.labelLoanProgram.Size = new System.Drawing.Size(133, 15);
            this.labelLoanProgram.TabIndex = 0;
            this.labelLoanProgram.Text = "Кредитная программа:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 63);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(75, 15);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(177, 105);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(97, 32);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(296, 105);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(97, 32);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(152, 60);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(106, 23);
            this.textBoxCount.TabIndex = 5;
            // 
            // comboBoxLoanProgram
            // 
            this.comboBoxLoanProgram.FormattingEnabled = true;
            this.comboBoxLoanProgram.Location = new System.Drawing.Point(152, 19);
            this.comboBoxLoanProgram.Name = "comboBoxLoanProgram";
            this.comboBoxLoanProgram.Size = new System.Drawing.Size(241, 23);
            this.comboBoxLoanProgram.TabIndex = 6;
            // 
            // FormClientLoanProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 148);
            this.Controls.Add(this.comboBoxLoanProgram);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelLoanProgram);
            this.Name = "FormClientLoanProgram";
            this.Text = "Кредитные программы клиента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelLoanProgram;
        private Label labelCount;
        private Button buttonSave;
        private Button buttonCancel;
        private TextBox textBoxCount;
        private ComboBox comboBoxLoanProgram;
    }
}