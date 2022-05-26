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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace BankViewManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuItemCurrency_Click(object sender, RoutedEventArgs e)
        {
            var form = App.Container.Resolve<CurrenciesWindow>();
            form.ShowDialog();
        }

        private void menuItemLoanProgram_Click(object sender, RoutedEventArgs e)
        {
            var form = App.Container.Resolve<LoanProgramsWindow>();
            form.ShowDialog();
        }

        private void menuItemTerm_Click(object sender, RoutedEventArgs e)
        {
            var form = App.Container.Resolve<TermsWindow>();
            form.ShowDialog();
        }

        private void menuItemGetList_Click(object sender, RoutedEventArgs e)
        {
            var form = App.Container.Resolve<DepositListWindow>();
            form.ShowDialog();
        }

        private void menuItemReport_Click(object sender, RoutedEventArgs e)
        {
            var form = App.Container.Resolve<ReportWindow>();
            form.ShowDialog();
        }

        private void menuItemBindCurrency_Click(object sender, RoutedEventArgs e)
        {
            var form = App.Container.Resolve<LinkCurrencyWindow>();
            form.ShowDialog();
        }
    }
}
