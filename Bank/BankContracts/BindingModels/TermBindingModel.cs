using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BindingModels
{
    public class TermBindingModel
    {
        public int? Id { get; set; }
        public DateTime StartTerm { get; set; }
        public DateTime EndTerm { get; set; }
    }
}
