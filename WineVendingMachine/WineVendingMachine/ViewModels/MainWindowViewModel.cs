using Prism.Mvvm;

namespace WineVendingMachine.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Wine Vending Machine";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
