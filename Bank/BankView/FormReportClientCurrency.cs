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
using BankContracts.BindingModels;

namespace BankView
{
    public partial class FormReportClientCurrency : Form
    {
        private readonly IClientLogic _logicC;
        private readonly IReportLogic _logicR;
        public FormReportClientCurrency(IClientLogic logicC, IReportLogic logicR)
        {
            InitializeComponent();
            _logicC = logicC;
            _logicR = logicR;
        }
        private void FormReportClientCurrency_Load(object sender, EventArgs e)
        {
            try
            {
                var list = _logicC.Read(null);
                if (list != null)
                {
                    string clientInfo = string.Empty;
                    foreach (var client in list)
                    {
                        clientInfo = client.ClientFIO + " " + client.PassportData;
                        checkedListBoxClients.Items.Add(clientInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonWord_Click(object sender, EventArgs e)
        {
            foreach (var client in checkedListBoxClients.CheckedItems)
            {
                
            }
            _logicR.GetClientCurrency(new ReportBindingModel
            {
                //Clients = checkedListBoxClients.Items
            });
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }        
    }
}
