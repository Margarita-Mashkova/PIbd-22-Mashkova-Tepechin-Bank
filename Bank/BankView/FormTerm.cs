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
    public partial class FormTerm : Form
    {
        private readonly ITermLogic _logicT;
        private readonly ILoanProgramLogic _logicLP;
        public int Id { set { id = value; } }
        private int? id;
        public FormTerm(ITermLogic logicT, ILoanProgramLogic logicLP)
        {
            InitializeComponent();
            _logicT = logicT;
            _logicLP = logicLP;
        }

        private void FormTerm_Load(object sender, EventArgs e)
        {
            try
            {
                List<LoanProgramViewModel> list = _logicLP.Read(null);
                if (list != null)
                {
                    comboBoxLoanPrograms.DisplayMember = "LoanProgramName";
                    comboBoxLoanPrograms.ValueMember = "Id";
                    comboBoxLoanPrograms.DataSource = list;
                    comboBoxLoanPrograms.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dateTimePickerStart.Text))
            {
                MessageBox.Show("Заполните поле 'Дата начала'", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(dateTimePickerEnd.Text))
            {
                MessageBox.Show("Заполните поле 'Дата конца'", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxLoanPrograms.SelectedValue == null)
            {
                MessageBox.Show("Выберите кредитную программу", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicT.CreateOrUpdate(new TermBindingModel
                {
                    StartTerm = dateTimePickerStart.Value,
                    EndTerm = dateTimePickerEnd.Value,
                    LoanProgramId = ((LoanProgramViewModel)comboBoxLoanPrograms.SelectedItem).Id,
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
    }
}
