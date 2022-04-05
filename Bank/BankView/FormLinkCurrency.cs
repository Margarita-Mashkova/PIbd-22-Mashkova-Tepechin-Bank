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
    public partial class FormLinkCurrency : Form
    {
        private readonly IDepositLogic _logicD;
        private readonly ICurrencyLogic _logicC;
        private Dictionary<int, (string, decimal)> currencyDeposits;
        public FormLinkCurrency(IDepositLogic logicD, ICurrencyLogic logicC)
        {
            InitializeComponent();
            _logicC = logicC;
            _logicD = logicD;
        }

        private void buttonLink_Click(object sender, EventArgs e)
        {
            /*TODO: Сделать привязку
            CurrencyViewModel view = _logicC.Read(new CurrencyBindingModel { Id = ((CurrencyBindingModel)comboBoxCurrency.SelectedItem).Id })?[0];
            currencyDeposits = view.CurrencyDeposits;
            checkedListBoxDeposits.CheckedItems
            currencyDeposits.Add();
            
            _logicC.CreateOrUpdate(new CurrencyBindingModel
            {
                Id = view.Id,
                CurrencyName = view.CurrencyName,
                DateAdding = view.DateAdding,

                CurrencyDeposits = checkedListBoxDeposits.CheckedItems.Cast()
                
            });
            */
            if (comboBoxCurrency.SelectedValue == null)
            {
                MessageBox.Show("Выберите валюту", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormLinkCurrency_Load(object sender, EventArgs e)
        {
            try
            {
                List<CurrencyViewModel> listC = _logicC.Read(null);
                if (listC != null)
                {
                    comboBoxCurrency.DisplayMember = "CurrencyName";
                    comboBoxCurrency.ValueMember = "Id";
                    comboBoxCurrency.DataSource = listC;
                    comboBoxCurrency.SelectedItem = null;
                }

                List<DepositViewModel> listD = _logicD.Read(null);
                if (listC != null)
                {
                    checkedListBoxDeposits.DisplayMember = "DepositName";
                    checkedListBoxDeposits.ValueMember = "Id";
                    checkedListBoxDeposits.DataSource = listD;
                    checkedListBoxDeposits.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}
