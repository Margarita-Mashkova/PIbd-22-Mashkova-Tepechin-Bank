using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankViewManager
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private readonly IManagerLogic _logic;
        public RegistrationWindow(IManagerLogic logic)
        {
            _logic = logic;
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Заполните логин", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Password))
            {
                MessageBox.Show("Заполните пароль", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxFio.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(textBoxLogin.Text, @"([a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+)"))
            {
                textBoxLogin.Focus();
                MessageBox.Show("Введеный логин не является адресом электронной почты", "Ошибка", MessageBoxButton.OK,
              MessageBoxImage.Error);
                return;
            }
            if (textBoxPassword.Password.Length<6)
            {
                MessageBox.Show("Пароль должен иметь длину не менее 6 символов", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(textBoxFio.Text, @"([А-ЯЁ][а-яё]+[\-\s]?){3,}"))
            {
                textBoxLogin.Focus();
                MessageBox.Show("Неправильный ввод ФИО", "Ошибка", MessageBoxButton.OK,
              MessageBoxImage.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new ManagerBindingModel
                {
                    Email = textBoxLogin.Text,
                    Password = textBoxPassword.Password,
                    ManagerFIO = textBoxFio.Text
                });
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }
    }
}
