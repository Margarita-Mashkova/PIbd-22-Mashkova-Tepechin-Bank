using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace BankView
{
    public partial class FormMainManager : Form
    {
        public FormMainManager()
        {
            InitializeComponent();
        }

        private void валютыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormCurrencies>();
            form.ShowDialog();
        }

        private void кредитныеПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormLoanPrograms>();
            form.ShowDialog();
        }

        private void срокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormTerms>();
            form.ShowDialog();
        }

        private void получениеСпискаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var form = Program.Container.Resolve<FormDepositList>();
            //form.ShowDialog();
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var form = Program.Container.Resolve<FormReport>();
            //form.ShowDialog();
        }

        private void привязатьВалютуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormLinkCurrency>();
            form.ShowDialog();
        }
    }
}
