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

namespace BankView
{
    public partial class FormCurrency : Form
    {
        public int Id { set { id = value; } }
        private readonly ICurrencyLogic _logic;
        private int? id;
        public FormCurrency(ICurrencyLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxExchange.Text))
            {
                MessageBox.Show("Заполните курс", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new CurrencyBindingModel
                {
                    Id = id,
                    CurrencyName = textBoxName.Text,
                    RubExchangeRate = Convert.ToDecimal(textBoxExchange.Text),
                    ManagerId = Program.Manager.Id
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
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

        private void FormCurrency_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logic.Read(new CurrencyBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.CurrencyName;
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
}
