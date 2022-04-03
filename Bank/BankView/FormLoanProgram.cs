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
using Unity;

namespace BankView
{
    public partial class FormLoanProgram : Form
    {
        public int Id { set { id = value; } }
        private readonly ILoanProgramLogic _logic;
        private int? id;
        private Dictionary<int, (string, decimal)> loanProgramCurrencies;

        public FormLoanProgram(ILoanProgramLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormLoanProgram_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    LoanProgramViewModel view = _logic.Read(new LoanProgramBindingModel
                    {
                        Id = id.Value 
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.LoanProgramName;
                        textBoxRate.Text = view.InterestRate.ToString();
                        loanProgramCurrencies = view.LoanProgramCurrencies;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                loanProgramCurrencies = new Dictionary<int, (string, decimal)>();
            }
        }

        private void butttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormLoanProgramCurrency>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (loanProgramCurrencies.ContainsKey(form.Id))
                {
                    loanProgramCurrencies[form.Id] = (form.CurrencyName, form.RubExchangeRate);
                }
                else
                {
                    loanProgramCurrencies.Add(form.Id, (form.CurrencyName, form.RubExchangeRate));
                }
                LoadData();
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormLoanProgramCurrency>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                
                if (form.ShowDialog() == DialogResult.OK)
                {
                    loanProgramCurrencies[form.Id] = (form.CurrencyName, form.RubExchangeRate);
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        loanProgramCurrencies.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxRate.Text))
            {
                MessageBox.Show("Заполните процентную ставку", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (loanProgramCurrencies == null || loanProgramCurrencies.Count == 0)
            {
                MessageBox.Show("Заполните валюты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new LoanProgramBindingModel
                {
                    Id = id,
                    LoanProgramName = textBoxName.Text,
                    InterestRate = Convert.ToDecimal(textBoxRate.Text),
                    LoanProgramCurrencies = loanProgramCurrencies,
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

        private void LoadData()
        {
            try
            {
                if (loanProgramCurrencies != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var lpc in loanProgramCurrencies)
                    {
                        dataGridView.Rows.Add(new object[] { lpc.Key, lpc.Value.Item1, lpc.Value.Item2 });
                    }
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
