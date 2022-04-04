using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.StoragesContracts;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBusinessLogic.BusinessLogics
{
    public class ReportLogic : IReportLogic
    {
        private readonly IDepositStorage _depositStorage;
        private readonly ILoanProgramStorage _loanProgramStorage;
        private readonly IClientStorage _clientStorage;
        private readonly ICurrencyStorage _currencyStorage;
        public ReportLogic(IDepositStorage depositStorage, ILoanProgramStorage loanProgramStorage, IClientStorage clientStorage, ICurrencyStorage currencyStorage)
        {
            _depositStorage = depositStorage;
            _loanProgramStorage = loanProgramStorage;
            _clientStorage = clientStorage;
            _currencyStorage = currencyStorage;
        }

        public List<ReportClientCurrencyViewModel> GetClientCurrency()
        {
            var clients = _clientStorage.GetFullList();
            var list = new List<ReportClientCurrencyViewModel>();
            foreach (var client in clients)
            {
                var record = new ReportClientCurrencyViewModel
                {
                    ClientFIO = client.ClientFIO,
                    Currencies = new List<Tuple<string>>(),
                    LoanProgramName = string.Empty
                };
                foreach (var loanProgram in client.ClientLoanPrograms)
                {
                    var model = _loanProgramStorage.GetElement(new LoanProgramBindingModel { Id = loanProgram.Key });
                    foreach (var currency in model.LoanProgramCurrencies)
                    {
                        record.Currencies.Add(new Tuple<string>(currency.Value.Item1));
                        record.LoanProgramName = model.LoanProgramName;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportLoanProgramDepositViewModel> GetLoanProgramDeposit()
        {
            var loanPrograms = _loanProgramStorage.GetFullList();
            var list = new List<ReportLoanProgramDepositViewModel>();
            foreach (var loanProgram in loanPrograms)
            {
                var record = new ReportLoanProgramDepositViewModel
                {
                    LoanProgramName = loanProgram.LoanProgramName,
                    Deposits = new List<Tuple<string>>(),
                    CurrencyName = string.Empty
                };
                foreach (var lc in loanProgram.LoanProgramCurrencies)
                {
                    var model = _currencyStorage.GetElement(new CurrencyBindingModel { Id = lc.Key });
                    foreach (var currency in model.)
                    {
                        record.Currencies.Add(new Tuple<string>(currency.Value.Item1));
                        record.LoanProgramName = model.LoanProgramName;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        public void SaveClientCurrencyToExcelFile(ReportBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void SaveClientCurrencyToWordFile(ReportBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void SaveLoanProgramDepositToExcelFile(ReportBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void SaveLoanProgramDepositToWordFile(ReportBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
