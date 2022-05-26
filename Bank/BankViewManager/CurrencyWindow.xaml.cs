using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для CurrencyWindow.xaml
    /// </summary>
    public partial class CurrencyWindow : Window
    {
        public int Id { set { id = value; } }
        private readonly ICurrencyLogic _logic;
        private int? id;
        public CurrencyWindow(ICurrencyLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxRate.Text))
            {
                MessageBox.Show("Заполните курс", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new CurrencyBindingModel
                {
                    Id = id,
                    CurrencyName = textBoxName.Text,
                    RubExchangeRate = Convert.ToDecimal(textBoxRate.Text),
                    DateAdding = DateTime.Now,
                    ManagerId = App.Manager.Id
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = false;
            Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logic.Read(new CurrencyBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.CurrencyName;
                        textBoxRate.Text = view.RubExchangeRate.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                   MessageBoxImage.Error);
                }
            }
        }
    }
}
