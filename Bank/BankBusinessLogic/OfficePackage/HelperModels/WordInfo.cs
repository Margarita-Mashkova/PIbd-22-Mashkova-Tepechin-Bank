using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankContracts.ViewModels;

namespace FlowerShopBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        //TODO: черновик!
        public List<ClientViewModel> Clients { get; set; }
        public List<LoanProgramViewModel> LoanPrograms { get; set; }
    }
}
