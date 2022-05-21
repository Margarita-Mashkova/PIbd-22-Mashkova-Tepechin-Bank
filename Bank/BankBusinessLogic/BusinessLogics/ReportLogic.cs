using BankBusinessLogic.OfficePackage;
using BankBusinessLogic.OfficePackage.HelperModels;
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
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToPdf _saveToPdf;


        public ReportLogic(IDepositStorage depositStorage, ILoanProgramStorage loanProgramStorage,
            IClientStorage clientStorage, ICurrencyStorage currencyStorage, AbstractSaveToWord saveToWord,
            AbstractSaveToExcel saveToExcel, AbstractSaveToPdf saveToPdf)
        {
            _depositStorage = depositStorage;
            _loanProgramStorage = loanProgramStorage;
            _clientStorage = clientStorage;
            _currencyStorage = currencyStorage;
            _saveToWord = saveToWord;
            _saveToExcel = saveToExcel;
            _saveToPdf = saveToPdf;
        }

        public List<ReportClientCurrencyViewModel> GetClientCurrency(ReportBindingModel model)
        {
            var clients = model.Clients;
            var list = new List<ReportClientCurrencyViewModel>();
            foreach (var client in clients)
            {
                var record = new ReportClientCurrencyViewModel
                {
                    ClientFIO = client.ClientFIO,
                    Currencies = new List<Tuple<string>>(),
                    LoanProgramName = string.Empty
                };
                foreach (var loanProgramKVP in client.ClientLoanPrograms)
                {
                    var lp = _loanProgramStorage.GetElement(new LoanProgramBindingModel { Id = loanProgramKVP.Key });
                    foreach (var currency in lp.LoanProgramCurrencies)
                    {
                        record.Currencies.Add(new Tuple<string>(currency.Value.Item1));
                        record.LoanProgramName = lp.LoanProgramName;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportClientsViewModel> GetClients(ReportBindingModel model)
        {
            var list = new List<ReportClientsViewModel>();
            var clients = _clientStorage.GetFilteredList(new ClientBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                ClerkId = model.ClerkId
            });
            foreach (var client in clients)
            {
                var record = new ReportClientsViewModel
                {
                    ClientFIO = client.ClientFIO,
                    DateVisit = client.DateVisit,
                    DepositCurrencies = new List<(DepositViewModel, List<CurrencyViewModel>)>()
                };
                var deposits = _depositStorage.GetFullList().Where(rec => rec.DepositClients.Keys.ToList().Contains(client.Id)).ToList();
                foreach (var deposit in deposits)
                {
                    var currencies = _currencyStorage.GetFullList().Where(rec => rec.CurrencyDeposits.Keys.ToList().Contains(deposit.Id)).ToList();
                    record.DepositCurrencies.Add((deposit, currencies));
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportCurrenciesViewModel> GetCurrencies(ReportBindingModel model)
        {
            var list = new List<ReportCurrenciesViewModel>();
            var currencies = _currencyStorage.GetFilteredList(new CurrencyBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                ManagerId = model.ManagerId
            });
            foreach (var currency in currencies)
            {
                var record = new ReportCurrenciesViewModel
                {
                    CurrencyName = currency.CurrencyName,
                    DateAdding = currency.DateAdding,
                    Deposits = new List<DepositViewModel>(),
                    LoanPrograms = new List<LoanProgramViewModel>()
                };
                foreach (var depositKVP in currency.CurrencyDeposits)
                {
                    var deposit = _depositStorage.GetElement(new DepositBindingModel { Id = depositKVP.Key });
                    record.Deposits.Add(deposit);
                }
                record.LoanPrograms = _loanProgramStorage.GetFullList()
                    .Where(rec => rec.LoanProgramCurrencies.Keys.ToList().Contains(currency.Id)).ToList();
                list.Add(record);
            }

            return list;
        }

        public List<ReportLoanProgramDepositViewModel> GetLoanProgramDeposit(ReportBindingModel model)
        {
            var loanPrograms = model.LoanPrograms;
            var list = new List<ReportLoanProgramDepositViewModel>();
            foreach (var loanProgram in loanPrograms)
            {
                var record = new ReportLoanProgramDepositViewModel
                {
                    LoanProgramName = loanProgram.LoanProgramName,
                    Deposits = new List<Tuple<string, decimal>>(),
                    CurrencyName = string.Empty
                };
                foreach (var currencyKVP in loanProgram.LoanProgramCurrencies)
                {
                    var currency = _currencyStorage.GetElement(new CurrencyBindingModel { Id = currencyKVP.Key });
                    foreach (var deposit in currency.CurrencyDeposits)
                    {
                        record.Deposits.Add(new Tuple<string, decimal>(deposit.Value.Item1, deposit.Value.Item2));
                        record.CurrencyName = currency.CurrencyName;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        public void SaveClientCurrencyToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReportClerk(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Валюты по клиентам",
                ClientCurrency = GetClientCurrency(model)
            });
        }

        public void SaveClientCurrencyToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDocClerk(new WordInfo
            {
                FileName = model.FileName,
                Title = "Валюты по клиентам",
                ClientCurrency = GetClientCurrency(model),
            });
        }

        public void SaveLoanProgramDepositToExcelFile(ReportBindingModel model)
        {
           
            _saveToExcel.CreateReportManager(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Вклады по кредитным программам",
                LoanProgramDeposit = GetLoanProgramDeposit(model)
            });
        }

        public void SaveLoanProgramDepositToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDocManager(new WordInfo
            {
                FileName = model.FileName,
                Title = "Вклады по кредитным программам",
                LoanProgramDeposit = GetLoanProgramDeposit(model),
            });
        }
        public void SaveCurrenciesToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDocManager(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Сведения по валюте",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Currencies = GetCurrencies(model)
            });
        }
        public void SaveClientsToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDocManager(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Сведения по валюте",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Currencies = GetCurrencies(model)
            });
        }
    }
}
