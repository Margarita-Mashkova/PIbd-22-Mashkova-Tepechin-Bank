
namespace BankView
{
    partial class FormMainManager
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.валютыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кредитныеПрограммыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.срокиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.получениеСпискаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.привязатьВалютуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.валютыToolStripMenuItem,
            this.кредитныеПрограммыToolStripMenuItem,
            this.срокиToolStripMenuItem,
            this.получениеСпискаToolStripMenuItem,
            this.отчетToolStripMenuItem,
            this.привязатьВалютуToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // валютыToolStripMenuItem
            // 
            this.валютыToolStripMenuItem.Name = "валютыToolStripMenuItem";
            this.валютыToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.валютыToolStripMenuItem.Text = "Валюты";
            this.валютыToolStripMenuItem.Click += new System.EventHandler(this.валютыToolStripMenuItem_Click);
            // 
            // кредитныеПрограммыToolStripMenuItem
            // 
            this.кредитныеПрограммыToolStripMenuItem.Name = "кредитныеПрограммыToolStripMenuItem";
            this.кредитныеПрограммыToolStripMenuItem.Size = new System.Drawing.Size(148, 20);
            this.кредитныеПрограммыToolStripMenuItem.Text = "Кредитные программы";
            this.кредитныеПрограммыToolStripMenuItem.Click += new System.EventHandler(this.кредитныеПрограммыToolStripMenuItem_Click);
            // 
            // срокиToolStripMenuItem
            // 
            this.срокиToolStripMenuItem.Name = "срокиToolStripMenuItem";
            this.срокиToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.срокиToolStripMenuItem.Text = "Сроки";
            this.срокиToolStripMenuItem.Click += new System.EventHandler(this.срокиToolStripMenuItem_Click);
            // 
            // получениеСпискаToolStripMenuItem
            // 
            this.получениеСпискаToolStripMenuItem.Name = "получениеСпискаToolStripMenuItem";
            this.получениеСпискаToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.получениеСпискаToolStripMenuItem.Text = "Получение списка";
            this.получениеСпискаToolStripMenuItem.Click += new System.EventHandler(this.получениеСпискаToolStripMenuItem_Click);
            // 
            // отчетToolStripMenuItem
            // 
            this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            this.отчетToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.отчетToolStripMenuItem.Text = "Отчет";
            this.отчетToolStripMenuItem.Click += new System.EventHandler(this.отчетToolStripMenuItem_Click);
            // 
            // привязатьВалютуToolStripMenuItem
            // 
            this.привязатьВалютуToolStripMenuItem.Name = "привязатьВалютуToolStripMenuItem";
            this.привязатьВалютуToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.привязатьВалютуToolStripMenuItem.Text = "Привязать валюту";
            this.привязатьВалютуToolStripMenuItem.Click += new System.EventHandler(this.привязатьВалютуToolStripMenuItem_Click);
            // 
            // FormMainManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BankView.Properties.Resources.bank;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMainManager";
            this.Text = "Банк \"Вы банкрот\". Руководитель";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem валютыToolStripMenuItem;
        private ToolStripMenuItem кредитныеПрограммыToolStripMenuItem;
        private ToolStripMenuItem срокиToolStripMenuItem;
        private ToolStripMenuItem получениеСпискаToolStripMenuItem;
        private ToolStripMenuItem отчетToolStripMenuItem;
        private ToolStripMenuItem привязатьВалютуToolStripMenuItem;
    }
}