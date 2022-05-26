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
    /// Логика взаимодействия для LoanProgramCurrencyWindow.xaml
    /// </summary>
    public partial class LoanProgramCurrencyWindow : Window
    {
        public int Id
        {
            get { return Convert.ToInt32(comboBoxCurrencies.SelectedValue); }
            set { comboBoxCurrencies.SelectedValue = value; }
        }
        public string CurrencyName { get { return comboBoxCurrencies.Text; } }
        public decimal RubExchangeRate { get { return ((CurrencyViewModel)comboBoxCurrencies.SelectedItem).RubExchangeRate; } }
        public DateTime DateAdding { get { return ((CurrencyViewModel)comboBoxCurrencies.SelectedItem).DateAdding; } }
        public LoanProgramCurrencyWindow(ICurrencyLogic logic)
        {
            InitializeComponent();
            List<CurrencyViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxCurrencies.DisplayMemberPath = "CurrencyName";
                comboBoxCurrencies.SelectedValuePath = "Id";
                comboBoxCurrencies.ItemsSource = list;
                comboBoxCurrencies.SelectedItem = null;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxCurrencies.SelectedValue == null)
            {
                MessageBox.Show("Выберите валюту", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            DialogResult = true;
            Close();
        }
    }
}
