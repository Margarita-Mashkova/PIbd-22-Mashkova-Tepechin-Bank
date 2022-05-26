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
using BoldReports.Windows;
using Unity;

namespace BankViewManager
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private readonly IReportLogic _logicR;

        public ReportWindow(IReportLogic logicR)
        {
            InitializeComponent();
            _logicR = logicR;
            ReportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Report.rdlc");
            ReportViewer.ProcessingMode = BoldReports.UI.Xaml.ProcessingMode.Local;
        }

        private void buttonMake_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerStart.SelectedDate >= datePickerEnd.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!datePickerStart.SelectedDate.HasValue || !datePickerEnd.SelectedDate.HasValue)
            {
                MessageBox.Show("Выберите даты",
               "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var source = _logicR.GetCurrencies(new ReportBindingModel
                {
                    DateFrom = datePickerStart.SelectedDate,
                    DateTo = datePickerEnd.SelectedDate,
                    ManagerId = App.Manager.Id
                });

                ReportViewer.DataSources.Clear();
                ReportViewer.DataSources.Add(new ReportDataSource { Name = "DataSetCurrencies", Value = source });
                
                var parameters = new List<ReportParameter>();
                var values = new List<string>();
                values.Add("С " + datePickerStart.SelectedDate.Value.ToShortDateString() + " по " +
                        datePickerEnd.SelectedDate.Value.ToShortDateString());
                var parameter = new ReportParameter
                {
                    Name = "ReportParameter",
                    Values = values
                };
                parameters.Add(parameter);
                ReportViewer.SetParameters(parameters);
                
                ReportViewer.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
              MessageBoxImage.Error);
            }
            
        }

        private void buttonSendMail_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerStart.SelectedDate >= datePickerEnd.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!datePickerStart.SelectedDate.HasValue || !datePickerEnd.SelectedDate.HasValue)
            {
                MessageBox.Show("Выберите даты",
               "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var form = App.Container.Resolve<SendMailWindow>();
            form.DateFrom = datePickerStart.SelectedDate.Value;
            form.DateTo = datePickerEnd.SelectedDate.Value;
            form.ShowDialog();
        }
    }
}
