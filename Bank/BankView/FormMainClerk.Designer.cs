namespace BankView
{
    partial class FormMainClerk
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вкладыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополненияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.получениеСпискаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.привязкаКлиентовИВкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клиентыToolStripMenuItem,
            this.вкладыToolStripMenuItem,
            this.пополненияToolStripMenuItem,
            this.привязкаКлиентовИВкладовToolStripMenuItem,
            this.получениеСпискаToolStripMenuItem,
            this.отчётToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(665, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // вкладыToolStripMenuItem
            // 
            this.вкладыToolStripMenuItem.Name = "вкладыToolStripMenuItem";
            this.вкладыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.вкладыToolStripMenuItem.Text = "Вклады";
            this.вкладыToolStripMenuItem.Click += new System.EventHandler(this.вкладыToolStripMenuItem_Click);
            // 
            // пополненияToolStripMenuItem
            // 
            this.пополненияToolStripMenuItem.Name = "пополненияToolStripMenuItem";
            this.пополненияToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.пополненияToolStripMenuItem.Text = "Пополнения";
            // 
            // получениеСпискаToolStripMenuItem
            // 
            this.получениеСпискаToolStripMenuItem.Name = "получениеСпискаToolStripMenuItem";
            this.получениеСпискаToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.получениеСпискаToolStripMenuItem.Text = "Получение списка";
            // 
            // отчётToolStripMenuItem
            // 
            this.отчётToolStripMenuItem.Name = "отчётToolStripMenuItem";
            this.отчётToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.отчётToolStripMenuItem.Text = "Отчёт";
            // 
            // привязкаКлиентовИВкладовToolStripMenuItem
            // 
            this.привязкаКлиентовИВкладовToolStripMenuItem.Name = "привязкаКлиентовИВкладовToolStripMenuItem";
            this.привязкаКлиентовИВкладовToolStripMenuItem.Size = new System.Drawing.Size(182, 20);
            this.привязкаКлиентовИВкладовToolStripMenuItem.Text = "Привязка клиентов и вкладов";
            this.привязкаКлиентовИВкладовToolStripMenuItem.Click += new System.EventHandler(this.привязкаКлиентовИВкладовToolStripMenuItem_Click);
            // 
            // FormMainClerk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::BankView.Properties.Resources.bank;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(665, 350);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMainClerk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Банк\"Вы Банкрот\"";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem клиентыToolStripMenuItem;
        private ToolStripMenuItem вкладыToolStripMenuItem;
        private ToolStripMenuItem пополненияToolStripMenuItem;
        private ToolStripMenuItem получениеСпискаToolStripMenuItem;
        private ToolStripMenuItem отчётToolStripMenuItem;
        private ToolStripMenuItem привязкаКлиентовИВкладовToolStripMenuItem;
    }
}