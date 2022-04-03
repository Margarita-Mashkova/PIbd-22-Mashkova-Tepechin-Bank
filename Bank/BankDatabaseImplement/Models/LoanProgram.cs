﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDatabaseImplement.Models
{
    public class LoanProgram
    {
        public int Id { get; set; }

        [Required]
        public string LoanProgramName { get; set; }

        [Required]
        public decimal InterestRate { get; set; }

        [ForeignKey("LoanProgramId")]
        public virtual List<ClientLoanProgram> ClientLoanPrograms { get; set; }

        [ForeignKey("LoanProgramId")]
        public virtual List<LoanProgramCurrency> LoanProgramCurrencies { get; set; }

        [ForeignKey("LoanProgramId")]
        public virtual List<Term> Terms { get; set; }
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }

    }
}