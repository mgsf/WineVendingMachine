using WineVendingMachine.Core;
using WineVendingMachine.Modules.SellWine.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace WineVendingMachine.Modules.SellWine
{
    public class SellWineModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public SellWineModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "ViewA");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}