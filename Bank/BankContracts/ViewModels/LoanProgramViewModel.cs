using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.ViewModels
{
    public class LoanProgramViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название кредитной программы")]
        public string LoanProgramName { get; set; }

        [DisplayName("Процентная ставка")]
        public decimal InterestRate { get; set; }

        [DisplayName("Валюты")]
        public Dictionary<int, string> LoanProgramCurrencies { get; set; }

    }
}
