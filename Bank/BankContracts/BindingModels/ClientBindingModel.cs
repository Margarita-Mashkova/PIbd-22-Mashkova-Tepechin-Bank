﻿using System;
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
    }
}