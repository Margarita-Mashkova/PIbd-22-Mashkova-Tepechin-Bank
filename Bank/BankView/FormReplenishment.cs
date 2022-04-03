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
using BankContracts.BindingModels;

namespace BankView
{
    public partial class FormReplenishment : Form
    {
        private readonly IReplenishmentLogic _logicR;
        private readonly IDepositLogic _logicD;
        private int? id;
        public int Id { set { id = value; } }
        public FormReplenishment(IDepositLogic logicD, IReplenishmentLogic logicR)
        {
            InitializeComponent();
            _logicR = logicR;
            _logicD = logicD;            
        }
        private void FormReplenishment_Load(object sender, EventArgs e)
        {
            try 
            {
                List<DepositViewModel> list = _logicD.Read(null);
                if (list != null)
                {
                    comboBoxDeposit.DisplayMember = "DepositName";
                    comboBoxDeposit.ValueMember = "Id";
                    comboBoxDeposit.DataSource = list;
                    comboBoxDeposit.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                _logicR.CreateOrUpdate(new ReplenishmentBindingModel
                {
                    Amount = Convert.ToInt32(textBoxAmount.Text),
                    DateReplenishment = DateTime.Now,
                    ClerkId = Program.Clerk.Id,
                    DepositId = ((DepositViewModel)comboBoxDeposit.SelectedItem).Id
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
