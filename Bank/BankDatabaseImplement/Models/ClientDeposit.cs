﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDatabaseImplement.Models
{
    public class ClientDeposit
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int DepositId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Deposit Deposit { get; set; }

    }
}
