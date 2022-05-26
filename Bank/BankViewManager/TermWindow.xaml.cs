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
    /// Логика взаимодействия для TermWindow.xaml
    /// </summary>
    public partial class TermWindow : Window
    {
        private readonly ITermLogic _logicT;
        private readonly ILoanProgramLogic _logicLP;
        public int Id { set { id = value; } }
        private int? id;
        

        public TermWindow(ITermLogic logicT, ILoanProgramLogic logicLP)
        {
            InitializeComponent();
            _logicT = logicT;
            _logicLP = logicLP;
            
        }
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(datePickerStart.Text))
            {
                MessageBox.Show("Заполните поле 'Дата начала'", "Ошибка",
               MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(datePickerStart.Text))
            {
                MessageBox.Show("Заполните поле 'Дата конца'", "Ошибка",
               MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (comboBoxLP.SelectedValue == null)
            {
                MessageBox.Show("Выберите кредитную программу", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            try
            {
                _logicT.CreateOrUpdate(new TermBindingModel
                {
                    Id = id,
                    StartTerm = datePickerStart.DisplayDate,
                    EndTerm = datePickerEnd.DisplayDate,
                    LoanProgramId = ((LoanProgramViewModel)comboBoxLP.SelectedItem).Id,
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

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<LoanProgramViewModel> list = _logicLP.Read(null);
                if (list != null)
                {

                    comboBoxLP.DisplayMemberPath = "LoanProgramName";
                    comboBoxLP.SelectedValuePath = "Id";
                    comboBoxLP.ItemsSource = list;
                    comboBoxLP.SelectedItem = null;
                }
                
                if (id.HasValue)
                {
                    TermViewModel view = _logicT.Read(new TermBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        datePickerStart.SelectedDate = view.StartTerm;
                        datePickerEnd.SelectedDate = view.EndTerm;
                        var item = _logicLP.Read(new LoanProgramBindingModel
                        {
                            Id = view.LoanProgramId
                        })?[0];
                        comboBoxLP.SelectedValue = item.Id;
                    }
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
