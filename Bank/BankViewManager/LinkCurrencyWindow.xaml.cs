using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.ViewModels;
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
    /// Логика взаимодействия для LinkCurrencyWindow.xaml
    /// </summary>
    public partial class LinkCurrencyWindow : Window
    {
        private readonly IDepositLogic _logicD;
        private readonly ICurrencyLogic _logicC;
        private Dictionary<int, string> currencyDeposits;
        public LinkCurrencyWindow(IDepositLogic logicD, ICurrencyLogic logicC)
        {
            InitializeComponent();
            _logicC = logicC;
            _logicD = logicD;
        }

        private void buttonLink_Click(object sender, RoutedEventArgs e)
        {
            CurrencyViewModel view = _logicC.Read(new CurrencyBindingModel { Id = ((CurrencyViewModel)comboBoxCurrency.SelectedItem).Id })?[0];
            currencyDeposits = new Dictionary<int, string>();
            foreach (var dep in listBox.SelectedItems)
            {
                var item = (DepositViewModel)dep;
                KeyValuePair<int, string> kvp = new(item.Id, (item.DepositName));
                currencyDeposits.Add(kvp.Key, kvp.Value);
            }
            _logicC.CreateOrUpdate(new CurrencyBindingModel
            {
                Id = view.Id,
                CurrencyName = view.CurrencyName,
                DateAdding = view.DateAdding,
                RubExchangeRate = view.RubExchangeRate,
                CurrencyDeposits = currencyDeposits
            });
            

            if (comboBoxCurrency.SelectedValue == null)
            {
                MessageBox.Show("Выберите валюту", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Привязка прошла успешно", "Сообщение",
               MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            Close();

        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<CurrencyViewModel> listC = _logicC.Read(null);
                if (listC != null)
                {
                    comboBoxCurrency.ItemsSource = listC;
                    comboBoxCurrency.SelectedValuePath = "Id";
                    comboBoxCurrency.DisplayMemberPath = "CurrencyName";
                    comboBoxCurrency.SelectedItem = null;
                }

                List<DepositViewModel> listD = _logicD.Read(null);
                if (listD != null)
                {
                    listBox.ItemsSource = listD;
                    listBox.SelectedValuePath = "Id";
                    listBox.SelectedItem = null;
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
