using Prism.Ioc;
using WineVendingMachine.Views;
using System.Windows;
using Prism.Modularity;
using WineVendingMachine.Modules.SellWine;
using WineVendingMachine.Services.Interfaces;
using WineVendingMachine.Services;

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
        }
    }
}
