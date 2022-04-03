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
using Unity;

namespace BankView
{
    public partial class FormLoanPrograms : Form
    {
        private readonly ILoanProgramLogic _logic;

        public FormLoanPrograms(ILoanProgramLogic logic)
        {
            InitializeComponent();
            _logic = logic;

        }

        private void FormLoanPrograms_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void butttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormLoanProgram>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormLoanProgram>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить?", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                   Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        _logic.Delete(new LoanProgramBindingModel { Id = id });
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
        private void LoadData()
        {
            try
            {
                var list = _logic.Read(null);
                if (list != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var lp in list)
                    {
                        string stringCurrencies = string.Empty;
                        foreach (var currency in lp.LoanProgramCurrencies)
                        {
                            stringCurrencies += currency.Key + ") " + currency.Value + ", ";
                        }
                        dataGridView.Rows.Add(new object[] { lp.Id, lp.LoanProgramName, lp.InterestRate, stringCurrencies[0..^2] });
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
