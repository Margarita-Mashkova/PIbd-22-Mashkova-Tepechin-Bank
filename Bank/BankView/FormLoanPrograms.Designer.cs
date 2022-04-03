namespace BankView
{
    partial class FormLoanPrograms
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.butttonAdd = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanProgramName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterestRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currencies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.LoanProgramName,
            this.InterestRate,
            this.Currencies});
            this.dataGridView.Location = new System.Drawing.Point(12, 54);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(634, 361);
            this.dataGridView.TabIndex = 0;
            // 
            // butttonAdd
            // 
            this.butttonAdd.Location = new System.Drawing.Point(652, 92);
            this.butttonAdd.Name = "butttonAdd";
            this.butttonAdd.Size = new System.Drawing.Size(144, 48);
            this.butttonAdd.TabIndex = 2;
            this.butttonAdd.Text = "Добавить";
            this.butttonAdd.UseVisualStyleBackColor = true;
            this.butttonAdd.Click += new System.EventHandler(this.butttonAdd_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(652, 167);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(144, 48);
            this.buttonChange.TabIndex = 3;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(652, 242);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(144, 48);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(652, 314);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(144, 48);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // LoanProgramName
            // 
            this.LoanProgramName.HeaderText = "Название";
            this.LoanProgramName.Name = "LoanProgramName";
            // 
            // InterestRate
            // 
            this.InterestRate.HeaderText = "Процентная ставка";
            this.InterestRate.Name = "InterestRate";
            // 
            // Currencies
            // 
            this.Currencies.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Currencies.HeaderText = "Валюты";
            this.Currencies.Name = "Currencies";
            // 
            // FormLoanPrograms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.butttonAdd);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormLoanPrograms";
            this.Text = "FormLoanPrograms";
            this.Load += new System.EventHandler(this.FormLoanPrograms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView;
        private Button butttonAdd;
        private Button buttonChange;
        private Button buttonDelete;
        private Button buttonUpdate;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn LoanProgramName;
        private DataGridViewTextBoxColumn InterestRate;
        private DataGridViewTextBoxColumn Currencies;
    }
}