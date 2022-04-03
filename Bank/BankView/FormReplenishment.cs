using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankContracts.ViewModels;
using BankContracts.BusinessLogicsContracts;

namespace BankView
{
    public partial class FormReplenishment : Form
    {
        public FormReplenishment(IDepositLogic logic)
        {
            InitializeComponent();
            List<DepositViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxDeposit.DisplayMember = "DepositName";
                comboBoxDeposit.ValueMember = "Id";
                comboBoxDeposit.DataSource = list;
                comboBoxDeposit.SelectedItem = null;
            }
        }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxDeposit.SelectedValue); }
            set { comboBoxDeposit.SelectedValue = value; }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAmount.Text))
            {
                MessageBox.Show("Заполните сумму пополнения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxDeposit.SelectedValue == null)
            {
                MessageBox.Show("Выберите вклад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
