using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using Unity;

namespace BankViewManager
{
    /// <summary>
    /// Логика взаимодействия для LoanProgramsWindow.xaml
    /// </summary>
    public partial class LoanProgramWindow : Window
    {
        public int Id { set { id = value; } }
        private readonly ILoanProgramLogic _logic;
        private int? id;
        private Dictionary<int, (string, decimal)> loanProgramCurrencies;

        public LoanProgramWindow(ILoanProgramLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            
            if (dataGrid.SelectedItems.Count == 1)
            {
                var form = App.Container.Resolve<LoanProgramCurrencyWindow>();
                PropertyInfo prop = dataGrid.SelectedItem.GetType().GetProperty("Item1");
                int id = Convert.ToInt32(prop.GetValue(dataGrid.SelectedItem, Array.Empty<object>()));
                form.Id = id;

                if (form.ShowDialog() == true)
                {
                    loanProgramCurrencies.Remove(id);
                    loanProgramCurrencies[form.Id] = (form.CurrencyName, form.RubExchangeRate);
                    LoadData();
                }
            }
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo,
               MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        PropertyInfo prop = dataGrid.SelectedItem.GetType().GetProperty("Item1");
                        loanProgramCurrencies.Remove(Convert.ToInt32(prop.GetValue(dataGrid.SelectedItem, Array.Empty<object>())));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                       MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxRate.Text))
            {
                MessageBox.Show("Заполните процентную ставку", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            if (loanProgramCurrencies == null || loanProgramCurrencies.Count == 0)
            {
                MessageBox.Show("Заполните валюты", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new LoanProgramBindingModel
                {
                    Id = id,
                    LoanProgramName = textBoxName.Text,
                    InterestRate = Convert.ToDecimal(textBoxRate.Text),
                    LoanProgramCurrencies = loanProgramCurrencies,
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

        private void LoadData()
        {
           
            try
            {
                if (loanProgramCurrencies != null)
                {
                    var currencies = loanProgramCurrencies.Select(rec=>(rec.Key, rec.Value.Item1,rec.Value.Item2).ToTuple());
                    dataGrid.ItemsSource = currencies;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    LoanProgramViewModel view = _logic.Read(new LoanProgramBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.LoanProgramName;
                        textBoxRate.Text = view.InterestRate.ToString();
                        loanProgramCurrencies = view.LoanProgramCurrencies;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                   MessageBoxImage.Error);
                }
            }
            else
            {
                loanProgramCurrencies = new Dictionary<int, (string, decimal)>();
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            
           var form = App.Container.Resolve<LoanProgramCurrencyWindow>();
           if (form.ShowDialog() == true)
           {
               if (loanProgramCurrencies.ContainsKey(form.Id))
               {
                   loanProgramCurrencies[form.Id] = (form.CurrencyName, form.RubExchangeRate);
               }
               else
               {
                   loanProgramCurrencies.Add(form.Id, (form.CurrencyName, form.RubExchangeRate));
               }
               LoadData();
           }
           
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

    }
}
