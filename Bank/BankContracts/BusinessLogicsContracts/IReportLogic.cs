using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
            //Clerk

        // Получение списка валют по выбранным клиентам
        List<ReportClientCurrencyViewModel> GetClientCurrency();

        // Сохранение вкладов по кредитным программам в файл-Word
        void SaveClientCurrencyToWordFile(ReportBindingModel model);

        // Сохранение вкладов по кредитным программам в файл-Excel
        void SaveClientCurrencyToExcelFile(ReportBindingModel model);

            //Manager

        // Получение списка вкладов по выбранным кредитным программам
        List<ReportLoanProgramDepositViewModel> GetLoanProgramDeposit();

        // Сохранение вкладов по кредитным программам в файл-Word
        void SaveLoanProgramDepositToWordFile(ReportBindingModel model);

        // Сохранение вкладов по кредитным программам в файл-Excel
        void SaveLoanProgramDepositToExcelFile(ReportBindingModel model);
    }
}
