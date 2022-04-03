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
    public partial class FormManagerAuthorization : Form
    {
        private readonly IManagerLogic _logic;
        public FormManagerAuthorization(IManagerLogic logic)
        {
            _logic = logic;
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormManagerRegistration>();
            form.ShowDialog();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Заполните логин", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните пароль", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                var list = _logic.Read(new ManagerBindingModel
                {
                    Email = textBoxLogin.Text,
                    Password = textBoxPassword.Text
                });
                
                if (list.Count > 0 && list != null)
                {
                    
                    Program.Manager = (list != null && list.Count > 0) ? list[0] : null;
                    var form = Program.Container.Resolve<FormMainManager>();
                    form.ShowDialog();  
                }
                else
                {
                    throw new Exception("Ошибка входа");
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
