using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankBusinessLogic.BusinessLogics;
using BankContracts.BusinessLogicsContracts;
using BankContracts.StoragesContracts;
using BankContracts.ViewModels;
using BankDatabaseImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace BankView
{
    static class Program
    {
        private static IUnityContainer container = null;
        public static ClerkViewModel Clerk;
        public static ManagerViewModel Manager;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormAuthorizationClerk>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IClerkStorage, ClerkStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientStorage, ClientStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICurrencyStorage, CurrencyStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDepositStorage, DepositStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ILoanProgramStorage, LoanProgramStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IManagerStorage, ManagerStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReplenishmentStorage, ReplenishmentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITermStorage, TermStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClerkLogic, ClerkLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientLogic, ClientLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICurrencyLogic, CurrencyLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDepositLogic, DepositLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ILoanProgramLogic, LoanProgramLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IManagerLogic, ManagerLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReplenishmentLogic, ReplenishmentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITermLogic, TermLogic>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<AbstractSaveToExcel, SaveToExcel>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<AbstractSaveToWord, SaveToWord>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<AbstractSaveToPdf, SaveToPdf>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}