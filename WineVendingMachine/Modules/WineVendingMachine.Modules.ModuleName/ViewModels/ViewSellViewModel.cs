using WineVendingMachine.Core.Mvvm;
using Prism.Regions;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;
using WineVendingMachine.Modules.SellWine.Domain;
using System;
using WineVendingMachine.Services.Interfaces;
using WineVendingMachine.Core.Framework;
using Prism.Events;
using WineVendingMachine.Core.Events;
using EventMoney = WineVendingMachine.Core.Events.Models;

namespace WineVendingMachine.Modules.SellWine.ViewModels
{
    public class ViewSellViewModel : RegionViewModelBase
    {

        private readonly VendingMachine _vendingMachine;
        private readonly VendingMachineRepository _repository;


        public ViewSellViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) :
            base(regionManager)
        {
           
            InsertTenCommand = new DelegateCommand(() => InsertMoney(Money.TenRupee));
            InsertTwentyCommand = new DelegateCommand(() => InsertMoney(Money.TwentyRupee));
            InsertFiftyCommand = new DelegateCommand(() => InsertMoney(Money.FiftyRupee));
            InsertHundredCommand = new DelegateCommand(() => InsertMoney(Money.HundredRupee));
            InsertFiveHundredCommand = new DelegateCommand(() => InsertMoney(Money.FiveHundredRupee));
            InsertThousandCommand = new DelegateCommand(() => InsertMoney(Money.ThousandRupee));
            ReturnMoneyCommand = new DelegateCommand(() => ReturnMoney());
            BuyWineCommand = new DelegateCommand<string>(BuyWine, WineAvailable);
            eventAggregator.GetEvent<MoneyLoadedEvent>().Subscribe(OnMoneyLoaded);

            _repository = new VendingMachineRepository();
            _vendingMachine = _repository.GetById(1);
            MoneyInMachine = _vendingMachine.MoneyInMachine;
        }



        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        private string _message = "Press to Insert Money";
        private string _moneyInTransaction = "";
        private Money _moneyInMachine;

        public Money MoneyInMachine
        {
            get { return _moneyInMachine; }
            set { SetProperty(ref _moneyInMachine, value); }
        }

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public string MoneyInTransaction
        {
            get { return _moneyInTransaction; }
            set { SetProperty(ref _moneyInTransaction, value); }
        }

        public ICommand InsertTenCommand { get; private set; }
        public ICommand InsertTwentyCommand { get; private set; }
        public ICommand InsertFiftyCommand { get; private set; }
        public ICommand InsertHundredCommand { get; private set; }
        public ICommand InsertFiveHundredCommand { get; private set; }
        public ICommand InsertThousandCommand { get; private set; }
        public ICommand ReturnMoneyCommand { get; private set; }
        public DelegateCommand<string> BuyWineCommand { get; set; }

        private void InsertMoney(Money money)
        {
            _vendingMachine.InsertMoney(money);
            MoneyInMachine = _vendingMachine.MoneyInMachine;
            Message = "Inserted " + money;
            MoneyInTransaction = "Total Inserted: " + _vendingMachine.MoneyInTransaction.ToString();
        }

        private void ReturnMoney()
        {
            _vendingMachine.ReturnMoney();
            MoneyInMachine = _vendingMachine.MoneyInMachine;
            MoneyInTransaction = "Money Returned";
        }

        private void BuyWine(string channelID)
        {
            _vendingMachine.BuyWine(int.Parse(channelID));
            Message = _message;
            MoneyInTransaction = "";
            MoneyInMachine = _vendingMachine.MoneyInMachine;
            _repository.Save(_vendingMachine);
        }

        private bool WineAvailable(string channelID)
        {
            return _vendingMachine.WineAvailable(int.Parse(channelID));
        }

        private void OnMoneyLoaded(EventMoney.Money emn)
        {
            Money money = new Money(emn.TenRupeeCount, emn.TwentyRupeeCount, emn.FiftyRupeeCount, emn.HundredRupeeCount, emn.FiveHundredRupeeCount, emn.HundredRupeeCount);
            _vendingMachine.LoadMoney(money);
            MoneyInMachine = _vendingMachine.MoneyInMachine;
        }
    }
}
