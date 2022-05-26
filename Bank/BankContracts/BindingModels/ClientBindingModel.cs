using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BindingModels
{
    public class ClientBindingModel
    {
        public int? Id { get; set; }
        public string ClientFIO { get; set; }
        public string PassportData {get; set;}
        public string TelephoneNumber { get; set;}
        public DateTime DateVisit { get; set; }
        public Dictionary<int, string> ClientLoanPrograms { get; set; }
        public int? ClerkId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
