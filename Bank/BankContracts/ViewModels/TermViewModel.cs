using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.ViewModels
{
    public class TermViewModel
    {
        public int Id { get; set; }
        [DisplayName("Начало срока")]
        public DateTime StartTerm { get; set; }
        [DisplayName("Окончание срока")]
        public DateTime EndTerm { get; set; }
    }
}
