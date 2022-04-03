namespace BankView
{
    partial class FormLoanProgram
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
            this.labelRate = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxRate = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.butttonAdd = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RubExchangeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(59, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название";
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(12, 50);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(112, 15);
            this.labelRate.TabIndex = 1;
            this.labelRate.Text = "Процентная ставка";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(142, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 23);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxRate
            // 
            this.textBoxRate.Location = new System.Drawing.Point(142, 47);
            this.textBoxRate.Name = "textBoxRate";
            this.textBoxRate.Size = new System.Drawing.Size(100, 23);
            this.textBoxRate.TabIndex = 3;
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Currency,
            this.RubExchangeRate});
            this.dataGridView.Location = new System.Drawing.Point(12, 96);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(560, 286);
            this.dataGridView.TabIndex = 4;
            // 
            // butttonAdd
            // 
            this.butttonAdd.Location = new System.Drawing.Point(623, 109);
            this.butttonAdd.Name = "butttonAdd";
            this.butttonAdd.Size = new System.Drawing.Size(144, 48);
            this.butttonAdd.TabIndex = 5;
            this.butttonAdd.Text = "Добавить";
            this.butttonAdd.UseVisualStyleBackColor = true;
            this.butttonAdd.Click += new System.EventHandler(this.butttonAdd_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(623, 180);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(144, 48);
            this.buttonChange.TabIndex = 6;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(623, 250);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(144, 48);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(623, 313);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(144, 48);
            this.buttonUpdate.TabIndex = 8;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(515, 401);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(123, 37);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(644, 401);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(123, 37);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Назад";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "id";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Currency
            // 
            this.Currency.HeaderText = "Валюта";
            this.Currency.Name = "Currency";
            // 
            // RubExchangeRate
            // 
            this.RubExchangeRate.HeaderText = "Курс";
            this.RubExchangeRate.Name = "RubExchangeRate";
            // 
            // FormLoanProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.butttonAdd);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.textBoxRate);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelRate);
            this.Controls.Add(this.labelName);
            this.Name = "FormLoanProgram";
            this.Text = "FormLoanProgram";
            this.Load += new System.EventHandler(this.FormLoanProgram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelName;
        private Label labelRate;
        private TextBox textBoxName;
        private TextBox textBoxRate;
        private DataGridView dataGridView;
        private Button butttonAdd;
        private Button buttonChange;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonSave;
        private Button buttonCancel;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Currency;
        private DataGridViewTextBoxColumn RubExchangeRate;
    }
}