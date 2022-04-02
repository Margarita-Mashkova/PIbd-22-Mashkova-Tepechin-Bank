using System;
using System.Collections.Generic;
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
    }
}
