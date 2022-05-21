using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
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
    public partial class FormMainClerk : Form
    {
        private readonly IReportLogic _logicR;
        public FormMainClerk(IReportLogic logicR)
        {
            InitializeComponent();
            _logicR = logicR;
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void вкладыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormDeposits>();
            form.ShowDialog();
        }

        private void привязкаКлиентовИВкладовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormClientDeposit>();
            form.ShowDialog();
        }

        private void пополненияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReplenishments>();
            form.ShowDialog();
        }

        private void получениеСпискаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportClientCurrency>();
            form.ShowDialog();
        }

        private void отчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logicR.SaveClientsToPdfFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName,
                        DateFrom = DateTime.MinValue,
                        DateTo = DateTime.MaxValue,
                        ClerkId = Program.Clerk.Id
                    });
                    MessageBox.Show("Выполнено", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
