using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.ViewModels
{
    public class Client
    {
        public int Id { get; set; }

        [DisplayName("ФИО")]
        public string ClientFIO { get; set; }

        [DisplayName("Паспортные данные")]
        public string PassportData { get; set; }

        [DisplayName("Контактный телефон")]
        public string TelephoneNumber { get; set; }
    }
}
