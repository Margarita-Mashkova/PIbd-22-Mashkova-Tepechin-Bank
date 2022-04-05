using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BindingModels
{
    public class CurrencyBindingModel
    {
        public int? Id { get; set; }
        public string CurrencyName { get; set; }
        public decimal RubExchangeRate { get; set; }
        public DateTime DateAdding { get; set; }
        public Dictionary<int, string> CurrencyDeposits { get; set; }
        public int? ManagerId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
