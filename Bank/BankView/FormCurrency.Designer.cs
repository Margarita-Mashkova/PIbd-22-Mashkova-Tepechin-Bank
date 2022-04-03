namespace BankView
{
    partial class FormCurrency
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
            this.labelExchange = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxExchange = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(26, 24);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(59, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название";
            // 
            // labelExchange
            // 
            this.labelExchange.AutoSize = true;
            this.labelExchange.Location = new System.Drawing.Point(26, 76);
            this.labelExchange.Name = "labelExchange";
            this.labelExchange.Size = new System.Drawing.Size(84, 15);
            this.labelExchange.TabIndex = 1;
            this.labelExchange.Text = "Курс в рублях";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(159, 21);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(156, 23);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxExchange
            // 
            this.textBoxExchange.Location = new System.Drawing.Point(159, 73);
            this.textBoxExchange.Name = "textBoxExchange";
            this.textBoxExchange.Size = new System.Drawing.Size(156, 23);
            this.textBoxExchange.TabIndex = 3;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(26, 120);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(262, 120);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Назад";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 155);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxExchange);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelExchange);
            this.Controls.Add(this.labelName);
            this.Name = "FormCurrency";
            this.Text = "FormCurrency";
            this.Load += new System.EventHandler(this.FormCurrency_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelName;
        private Label labelExchange;
        private TextBox textBoxName;
        private TextBox textBoxExchange;
        private Button buttonSave;
        private Button buttonCancel;
    }
}