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
using Unity;

namespace BankViewManager
{
    /// <summary>
    /// Логика взаимодействия для TermsWindow.xaml
    /// </summary>
    public partial class TermsWindow : Window
    {
        private readonly ITermLogic _logic;

        public TermsWindow(ITermLogic logic)
        {
            _logic = logic;
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = App.Container.Resolve<TermWindow>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count == 1)
            {
                var form = App.Container.Resolve<TermWindow>();
                form.Id = Convert.ToInt32(((TermViewModel)dataGrid.SelectedItem).Id);
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Удаление ", "Удалить срок?", MessageBoxButton.YesNo,
               MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id =
                   Convert.ToInt32(((TermViewModel)dataGrid.SelectedItem).Id);
                    try
                    {
                        _logic.Delete(new TermBindingModel { Id = id });
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

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = _logic.Read(new TermBindingModel { ManagerId = App.Manager.Id});
                if (list != null)
                {
                    dataGrid.ItemsSource = list;
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
