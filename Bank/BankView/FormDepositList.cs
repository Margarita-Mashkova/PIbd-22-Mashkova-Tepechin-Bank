using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankView
{
    public partial class FormDepositList : Form
    {
        private readonly ILoanProgramLogic _logicLP;
        private readonly IReportLogic _logicR;
        public FormDepositList(ILoanProgramLogic logicLP, IReportLogic logicR)
        {
            _logicLP = logicLP;
            _logicR = logicR;
            InitializeComponent();
        }

        private void FormDepositList_Load(object sender, EventArgs e)
        {
            try
            {

                List<LoanProgramViewModel> listLP = _logicLP.Read(null);
                if (listLP != null)
                {
                    checkedListBox.DataSource = listLP;
                    checkedListBox.DisplayMember = "LoanProgramName";
                    checkedListBox.ValueMember = "Id";
                    checkedListBox.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonWord_Click(object sender, EventArgs e)
        {
           
            var itemsLP = new List<LoanProgramViewModel>();
            foreach (var client in checkedListBox.CheckedItems)
            {
                itemsLP.Add((LoanProgramViewModel)client);
            }
           
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _logicR.SaveLoanProgramDepositToWordFile(new ReportBindingModel
                {
                    FileName = dialog.FileName,
                    LoanPrograms= itemsLP
            });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var itemsLP = new List<LoanProgramViewModel>();
            foreach (var client in checkedListBox.CheckedItems)
            {
                itemsLP.Add((LoanProgramViewModel)client);
            }
            /*
            using var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logicR.SaveLoanProgramDepositToExcelFile(new
                    ReportBindingModel
                    {
                        FileName = dialog.FileName,
                        LoanPrograms = itemsLP
                    });
                    MessageBox.Show("Выполнено", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            */
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logicR.SaveCurrenciesToPdfFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName,
                        DateFrom = DateTime.MinValue,
                        DateTo = DateTime.MaxValue,
                        ManagerId = Program.Manager.Id
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
