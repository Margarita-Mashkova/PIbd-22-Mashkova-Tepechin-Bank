using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.ViewModels
{
    public class CurrencyViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название валюты")]
        public string CurrencyName { get; set; }

        [DisplayName("Курс в рублях")]
        public decimal RubExchangeRate { get; set; }

        [DisplayName("Дата добавления")]
        public DateTime DateAdding { get; set; }
        [DisplayName("Вклады")]
        public Dictionary<int, (string, decimal)> CurrencyDeposits { get; set; }
    }
}
