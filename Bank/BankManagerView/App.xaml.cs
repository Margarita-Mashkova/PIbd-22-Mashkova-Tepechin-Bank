using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Lifetime;


namespace BankManagerView
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IUnityContainer container = null;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //AuthorizationWindow authorizationWindow = Container.Resolve<AuthorizationWindow>();
            //authorizationWindow.ShowDialog();
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
            currentContainer.RegisterType<IReportLogic, ReportLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToExcel, SaveToExcel>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToWord, SaveToWord>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToPdf, SaveToPdf>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
