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
    public partial class FormLoanProgramCurrency : Form
    {
        public int Id
        {
            get { return Convert.ToInt32(comboBoxCurrency.SelectedValue); }
            set { comboBoxCurrency.SelectedValue = value; }
        }
        public string CurrencyName { get { return comboBoxCurrency.Text; } }
        public decimal RubExchangeRate { get { return ((CurrencyViewModel)comboBoxCurrency.SelectedItem).RubExchangeRate; } }
        public FormLoanProgramCurrency(ICurrencyLogic logic)
        {
            InitializeComponent();
            List<CurrencyViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxCurrency.DisplayMember = "CurrencyName";
                comboBoxCurrency.ValueMember = "Id";
                comboBoxCurrency.DataSource = list;
                comboBoxCurrency.SelectedItem = null;
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
           
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
    }
}
