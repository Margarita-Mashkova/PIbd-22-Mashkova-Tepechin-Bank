using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankContracts.ViewModels;

namespace BankContracts.BindingModels
{
    public class ReportBindingModel
    {
        public string FileName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public List<ClientViewModel> Clients { get; set; }
        public List<LoanProgramViewModel> LoanPrograms { get; set; }
    }
}
