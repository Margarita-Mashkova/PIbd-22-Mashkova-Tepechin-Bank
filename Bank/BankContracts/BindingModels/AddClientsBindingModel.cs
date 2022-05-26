using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BindingModels
{
    public class AddClientsBindingModel
    {
        public int DepositId { get; set; }
        public List<int> ClientsId { get; set; }
    }
}
