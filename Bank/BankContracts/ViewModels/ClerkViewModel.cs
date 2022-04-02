using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BankContracts.ViewModels
{
    public class ClerkViewModel
    {
        public int Id { get; set; }

        [DisplayName("ФИО")]
        public string ClerkFIO { get; set; }

        [DisplayName("Логин")]
        public string Email { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
