﻿using BankContracts.ViewModels;

namespace BankBusinessLogic.OfficePackage.HelperModels
{
    public class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportCurrenciesViewModel> Currencies { get; set; }
        public List<ReportClientsViewModel> Clients { get; set; }
    }
}
