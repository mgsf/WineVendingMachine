using WineVendingMachine.Core.Mvvm;
using Prism.Regions;


namespace WineVendingMachine.Modules.SellWine.ViewModels
{
    public class ViewSellViewModel : RegionViewModelBase
    {
        public ViewSellViewModel(IRegionManager regionManager) :
            base(regionManager)
        {
            
        }

    }
}
