using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BindingModels
{
    public class ReplenishmentBindingModels
    {
        public int? Id { get; set; }
        public int Amount { get; set; }
        public DateTime DateReplenishment { get; set; }
    }
}
