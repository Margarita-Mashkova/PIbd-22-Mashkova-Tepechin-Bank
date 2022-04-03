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
    public partial class FormClientLoanProgram : Form
    {
        public FormClientLoanProgram(ILoanProgramLogic logic)
        {
            InitializeComponent();
            List<LoanProgramViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxLoanProgram.DisplayMember = "LoanProgramName";
                comboBoxLoanProgram.ValueMember = "Id";
                comboBoxLoanProgram.DataSource = list;
                comboBoxLoanProgram.SelectedItem = null;
            }
        }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxLoanProgram.SelectedValue); }
            set { comboBoxLoanProgram.SelectedValue = value; }
        }
        public string LoanProgramName { get { return comboBoxLoanProgram.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxLoanProgram.SelectedValue == null)
            {
                MessageBox.Show("Выберите кредитную программу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
