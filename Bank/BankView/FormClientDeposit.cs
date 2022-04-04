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
using BankContracts.StoragesContracts;

namespace BankView
{
    public partial class FormClientDeposit : Form
    {
        //TODO: Доделать!
        private readonly IDepositLogic _logicD;
        private readonly IClientLogic _logicC;
        private readonly IDepositStorage _depositStorage;
        private readonly IClientStorage _clientStorage;
        public FormClientDeposit(IDepositLogic logicD, IClientLogic logicC, IDepositStorage depositStorage, IClientStorage clientStorage)
        {
            InitializeComponent();
            _logicD = logicD;
            _logicC = logicC;
            _depositStorage = depositStorage;
            _clientStorage = clientStorage;
        }
        private void FormClientDeposit_Load(object sender, EventArgs e)
        {
            List<DepositViewModel> listD = _logicD.Read(null);
            if (listD != null)
            {
                comboBoxDeposit.DisplayMember = "DepositName";
                comboBoxDeposit.ValueMember = "Id";
                comboBoxDeposit.DataSource = listD;
                comboBoxDeposit.SelectedItem = null;
            }
            ///При загрузке формы подгружаем список клиентов.
            List<ClientViewModel> listC = _logicC.Read(null);
            if (listC != null)
            {
                comboBoxClient.DisplayMember = "ClientFIO";
                comboBoxClient.ValueMember = "Id";
                comboBoxClient.DataSource = listC;
                comboBoxClient.SelectedItem = null;
            }
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = _logicD.Read(null);
                if (list != null)
                {
                    dataGridView.Rows.Clear();
                    if (comboBoxDeposit.SelectedValue != null)
                    {
                        var deposit = _depositStorage.GetElement(new DepositBindingModel { DepositName = comboBoxDeposit.Text});
                        foreach (var client in deposit.DepositClients)
                        {
                            var clientModel = _clientStorage.GetElement(new ClientBindingModel { Id = client.Key });
                            dataGridView.Rows.Add(new object[] { clientModel.Id, clientModel.ClientFIO, clientModel.PassportData, clientModel.TelephoneNumber });
                        }                       
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
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //var deposit = _depositStorage.GetElement(new DepositBindingModel { DepositName = comboBoxDeposit.Text });
                var clientModel = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = ((ClientViewModel)comboBoxClient.SelectedItem).Id
                });
                //deposit.ClientDeposits.Add(clientModel.Id, comboBoxClient.Text);
                dataGridView.Rows.Add(new object[] { clientModel.Id, clientModel.ClientFIO, clientModel.PassportData, clientModel.TelephoneNumber});
            }
            LoadData();
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        _logicC.Delete(new ClientBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            var deposit = _depositStorage.GetElement(new DepositBindingModel { DepositName = comboBoxDeposit.Text });
            if (deposit.DepositClients == null || deposit.DepositClients.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы одного клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                //foreach ()
                //{
                    var clientModel = _clientStorage.GetElement(new ClientBindingModel
                    {
                        //Id = dataGridView.Rows[0].Cells[0].Value
                    });
                    deposit.DepositClients.Add(clientModel.Id, comboBoxClient.Text);
                //}
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
