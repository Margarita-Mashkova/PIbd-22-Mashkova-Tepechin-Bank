using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BindingModels
{
    public class DepositBindingModel
    {
        public int? Id { get; set; }
        public string DepositName { get; set; }
        public decimal DepositInterest { get; set; }
        public Dictionary<int, string> ClientDeposits { get; set; }
        public int? ClerkId { get; set; }
    }
}
