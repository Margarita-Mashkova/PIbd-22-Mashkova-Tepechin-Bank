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
    public partial class FormAuthorizationClerk : Form
    {
        private readonly IClerkLogic _logic;
        public FormAuthorizationClerk(IClerkLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormRegistrationClerk>();
            form.ShowDialog();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Заполните логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var list = _logic.Read(new ClerkBindingModel
                {
                    Email = textBoxEmail.Text,
                    Password = textBoxPassword.Text,
                });
                Program.Clerk = (list != null && list.Count > 0) ? list[0] : null;
                var form = Program.Container.Resolve<FormMainClerk>();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
