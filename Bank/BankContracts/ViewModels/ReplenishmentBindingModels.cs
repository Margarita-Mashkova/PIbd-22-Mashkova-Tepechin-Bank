using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.ViewModels
{
    public class ReplenishmentBindingModels
    {
        public int Id { get; set; }

        [DisplayName("Сумма пополнения")]
        public int Amount { get; set; }

        [DisplayName("Дата пополнения")]
        public DateTime DateReplenishment { get; set; }
    }
}
