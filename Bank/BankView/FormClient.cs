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
using BankContracts.ViewModels;
using Unity;

namespace BankView
{
    public partial class FormClient : Form
    {
        public int Id { set { id = value; } }
        private readonly IClientLogic _logic;
        private int? id;
        private Dictionary<int, (string, int)> clientLoanPrograms;
        public FormClient(IClientLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void FormClient_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ClientViewModel view = _logic.Read(new ClientBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxFIO.Text = view.ClientFIO;
                        textBoxPassportData.Text = view.PassportData;
                        textBoxTelephone.Text = view.TelephoneNumber;
                        clientLoanPrograms = view.ClientLoanPrograms;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                clientLoanPrograms = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (clientLoanPrograms != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var clp in clientLoanPrograms)
                    {
                        dataGridView.Rows.Add(new object[] { clp.Key, clp.Value.Item1, clp.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormClientLoanProgram>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (clientLoanPrograms.ContainsKey(form.Id))
                {
                    clientLoanPrograms[form.Id] = (form.LoanProgramName, form.Count);
                }
                else
                {
                    clientLoanPrograms.Add(form.Id, (form.LoanProgramName, form.Count));
                }
                LoadData();
            }
        }
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormClientLoanProgram>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = clientLoanPrograms[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    clientLoanPrograms[form.Id] = (form.LoanProgramName, form.Count);
                    LoadData();
                }
            }
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        clientLoanPrograms.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassportData.Text))
            {
                MessageBox.Show("Заполните паспортные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxTelephone.Text))
            {
                MessageBox.Show("Заполните контактный телефон", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clientLoanPrograms == null || clientLoanPrograms.Count == 0)
            {
                MessageBox.Show("Заполните кредитные программы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new ClientBindingModel
                {
                    Id = id,
                    ClientFIO = textBoxFIO.Text,
                    PassportData = textBoxPassportData.Text,
                    TelephoneNumber = textBoxTelephone.Text,
                    ClerkId = Program.Clerk.Id,
                    ClientLoanPrograms = clientLoanPrograms
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
