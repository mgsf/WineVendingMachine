using WineVendingMachine.Modules.MachineMgt.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using WineVendingMachine.Core;
using WineVendingMachine.Modules.MachineMgt.Domain;

namespace WineVendingMachine.Modules.MachineMgt
{
    public class MachineMgtModule : IModule
    {
        

        public MachineMgtModule()
        {
            
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            SessionFactory.Init(@"Server=.;Database=VendingMachine;Trusted_Connection=true");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}