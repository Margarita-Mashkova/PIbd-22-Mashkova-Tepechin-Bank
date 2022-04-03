
namespace BankView
{
    partial class FormTerm
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
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.comboBoxLoanPrograms = new System.Windows.Forms.ComboBox();
            this.labelLoanProgram = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(12, 25);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(74, 15);
            this.labelStart.TabIndex = 1;
            this.labelStart.Text = "Дата начала";
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Location = new System.Drawing.Point(12, 61);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(68, 15);
            this.labelEnd.TabIndex = 2;
            this.labelEnd.Text = "Дата конца";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(148, 19);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerStart.TabIndex = 3;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(148, 55);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerEnd.TabIndex = 4;
            // 
            // comboBoxLoanPrograms
            // 
            this.comboBoxLoanPrograms.FormattingEnabled = true;
            this.comboBoxLoanPrograms.Location = new System.Drawing.Point(148, 93);
            this.comboBoxLoanPrograms.Name = "comboBoxLoanPrograms";
            this.comboBoxLoanPrograms.Size = new System.Drawing.Size(200, 23);
            this.comboBoxLoanPrograms.TabIndex = 5;
            // 
            // labelLoanProgram
            // 
            this.labelLoanProgram.AutoSize = true;
            this.labelLoanProgram.Location = new System.Drawing.Point(12, 96);
            this.labelLoanProgram.Name = "labelLoanProgram";
            this.labelLoanProgram.Size = new System.Drawing.Size(130, 15);
            this.labelLoanProgram.TabIndex = 6;
            this.labelLoanProgram.Text = "Кредитная программа";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(431, 19);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(166, 36);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(431, 80);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(166, 36);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Назад";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 143);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelLoanProgram);
            this.Controls.Add(this.comboBoxLoanPrograms);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.labelStart);
            this.Name = "FormTerm";
            this.Text = "FormTerm";
            this.Load += new System.EventHandler(this.FormTerm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelStart;
        private Label labelEnd;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private ComboBox comboBoxLoanPrograms;
        private Label labelLoanProgram;
        private Button buttonSave;
        private Button buttonCancel;
    }
}