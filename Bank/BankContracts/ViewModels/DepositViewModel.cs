using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.ViewModels
{
    public class DepositViewModel
    {
        public int Id { get; set; }

        [DisplayName("Наименование вклада")]
        public string DepositName { get; set; }

        [DisplayName("Процентная ставка")]
        public decimal DepositInterest { get; set; }
    }
}
