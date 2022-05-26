using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.ViewModels;
using Microsoft.Win32;
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
    /// Логика взаимодействия для DepositListWindow.xaml
    /// </summary>
    public partial class DepositListWindow : Window
    {
        private readonly ILoanProgramLogic _logicLP;
        private readonly IReportLogic _logicR;
        public DepositListWindow(ILoanProgramLogic logicLP, IReportLogic logicR)
        {
            _logicLP = logicLP;
            _logicR = logicR;
            InitializeComponent();
        }

        private void buttonWord_Click(object sender, RoutedEventArgs e)
        {
            var itemsLP = new List<LoanProgramViewModel>();
            foreach (var check in listBox.SelectedItems)
            {
                itemsLP.Add((LoanProgramViewModel)check);
            }

            var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == true)
            {
                _logicR.SaveLoanProgramDepositToWordFile(new ReportBindingModel
                {
                    FileName = dialog.FileName,
                    LoanPrograms = itemsLP
                });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
        }

        private void buttonExcel_Click(object sender, RoutedEventArgs e)
        { 
            var itemsLP = new List<LoanProgramViewModel>();
           
            foreach (var check in listBox.SelectedItems)
            {     
                itemsLP.Add((LoanProgramViewModel)check);
            }
            
            var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    _logicR.SaveLoanProgramDepositToExcelFile(new
                    ReportBindingModel
                    {
                        FileName = dialog.FileName,
                        LoanPrograms = itemsLP
                    });
                    MessageBox.Show("Выполнено", "Успех",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
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

                List<LoanProgramViewModel> listLP = _logicLP.Read(null);
                if (listLP != null)
                {
                    listBox.ItemsSource = listLP;
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
