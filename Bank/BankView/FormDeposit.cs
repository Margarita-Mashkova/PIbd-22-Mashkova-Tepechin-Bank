using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;

namespace BankView
{
    public partial class FormDeposit : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private readonly IDepositLogic _logic;
        private Dictionary<int, string> clientDeposits;
        public FormDeposit(IDepositLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void FormDeposit_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logic.Read(new DepositBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxDepositName.Text = view.DepositName;
                        textBoxDepositInterest.Text = view.DepositInterest.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                clientDeposits = new Dictionary<int, string>();
            }
        }        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDepositName.Text))
            {
                MessageBox.Show("Заполните наименование вклада", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxDepositInterest.Text))
            {
                MessageBox.Show("Заполните процент по вкладу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new DepositBindingModel
                {
                    Id = id,
                    DepositName = textBoxDepositName.Text,
                    ClerkId = Program.Clerk.Id,
                    DepositInterest = Convert.ToDecimal(textBoxDepositInterest.Text),
                    ClientDeposits = clientDeposits
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
