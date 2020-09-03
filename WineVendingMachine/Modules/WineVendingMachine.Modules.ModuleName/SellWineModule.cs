using WineVendingMachine.Core;
using WineVendingMachine.Modules.SellWine.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using WineVendingMachine.Core.Framework;
using WineVendingMachine.Modules.SellWine.ViewModels;
using WineVendingMachine.Modules.SellWine.Domain;

namespace WineVendingMachine.Modules.SellWine
{
    public class SellWineModule : IModule
    {
        //private readonly IRegionManager _regionManager;

        public SellWineModule()
        {
            //_regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            SessionFactory.Init(@"Server=.;Database=VendingMachine;Trusted_Connection=true");
           //_regionManager.RequestNavigate(RegionNames.SellWine, "ViewSell");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewSell>();
           
        }
    }
}