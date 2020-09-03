using Prism.Ioc;
using WineVendingMachine.Views;
using System.Windows;
using Prism.Modularity;
using WineVendingMachine.Modules.SellWine;
using WineVendingMachine.Modules.MachineMgt;
using WineVendingMachine.Services.Interfaces;
using WineVendingMachine.Services;
using WineVendingMachine.Modules.SellWine.Views;
using WineVendingMachine.Modules.SellWine.ViewModels;

namespace WineVendingMachine
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
            
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<SellWineModule>();
            moduleCatalog.AddModule<MachineMgtModule>();
            
        }
    }
}
