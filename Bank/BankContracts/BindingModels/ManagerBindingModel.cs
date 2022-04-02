using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BindingModels
{
    public class ManagerBindingModel
    {
        public int? Id { get; set; }
        public string ManagerFIO { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
