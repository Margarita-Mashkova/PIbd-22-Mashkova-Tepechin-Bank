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
                    checkedListBox.DisplayMember = "LoanProgramName";
                    checkedListBox.ValueMember = "Id";
                    checkedListBox.DataSource = listLP;
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
            /*TODO: проверка replogic
            foreach(var item in )
            List<LoanProgramViewModel> items = (LoanProgramViewModel)checkedListBox.CheckedItems;
            var list = _logicR.GetLoanProgramDeposit(new ReportBindingModel
            {
                LoanPrograms = (List<LoanProgramViewModel>)checkedListBox.CheckedItems.Cast<LoanProgramViewModel>(),
            });
            */
            var itemsLP = new List<LoanProgramViewModel>();
            foreach (var client in checkedListBox.CheckedItems)
            {
                itemsLP.Add((LoanProgramViewModel)client);
            }
            var list = _logicR.GetLoanProgramDeposit(new ReportBindingModel
            {
                LoanPrograms = itemsLP
            });
            var list2 = _logicR.GetCurrencies(new ReportBindingModel
            {
                DateFrom = DateTime.MinValue,
                DateTo = DateTime.MaxValue
            });

        }
    }
}
