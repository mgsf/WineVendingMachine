using Prism.Commands;
using Prism.Mvvm;
using WineVendingMachine.Core.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineVendingMachine.Modules.MachineMgt.Domain;
using Prism.Regions;
using Prism.Events;
using WineVendingMachine.Core.Events;
using EventMoney = WineVendingMachine.Core.Events.Models;

namespace WineVendingMachine.Modules.MachineMgt.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private readonly VendingMachine _vendingMachine;
        private readonly VendingMachineRepository _repository;
        private readonly IEventAggregator _eventAggregator;

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            :base(regionManager)
        {
            LoadMoneyCommand = new DelegateCommand(LoadMoney);
            _eventAggregator = eventAggregator;
            Message = "View A from your Prism Module";
            _repository = new VendingMachineRepository();
            _vendingMachine = _repository.GetById(1);
            MoneyInMachine = _vendingMachine.MoneyInMachine;
        }

        public ICommand LoadMoneyCommand { get; private set; }
        public void LoadMoney()
        {
            Money mn = new Money(TenRupeeNotes, TwentyRupeeNotes, FiftyRupeeNotes, HundredRupeeNotes, FiveHundredRupeeNotes, ThousandRupeeNotes);
            EventMoney.Money emn = new EventMoney.Money(TenRupeeNotes, TwentyRupeeNotes, FiftyRupeeNotes, HundredRupeeNotes, FiveHundredRupeeNotes, ThousandRupeeNotes);
            _vendingMachine.InsertMoney(mn);
            MoneyInMachine = _vendingMachine.MoneyInMachine;
            _repository.Save(_vendingMachine);
            _eventAggregator.GetEvent<MoneyLoadedEvent>().Publish(emn);
        }

        private Money _moneyInMachine;

        public Money MoneyInMachine
        {
            get { return _moneyInMachine; }
            set { SetProperty(ref _moneyInMachine, value); }
        }

        private int _tenRupeeNotes = 0;
        private int _twentyRupeeNotes =0;
        private int _fiftyRupeeNots =0;
        private int _hundredRupeeNotes =0;
        private int _fiveHundredRupeeNotes =0;
        private int _thousandRupeeNotes =0;

        public int TenRupeeNotes 
        {
            get { return _tenRupeeNotes; }
            set { SetProperty(ref _tenRupeeNotes, value); }
        }

        public int TwentyRupeeNotes
        {
            get { return _twentyRupeeNotes; }
            set { SetProperty(ref _twentyRupeeNotes, value); }
        }

        public int FiftyRupeeNotes
        {
            get { return _fiftyRupeeNots; }
            set { SetProperty(ref _fiftyRupeeNots, value); }
        }

        public int HundredRupeeNotes
        {
            get { return _hundredRupeeNotes; }
            set { SetProperty(ref _hundredRupeeNotes, value); }
        }

        public int FiveHundredRupeeNotes
        {
            get { return _fiveHundredRupeeNotes; }
            set { SetProperty(ref _fiveHundredRupeeNotes, value); }
        }
        public int ThousandRupeeNotes
        {
            get { return _thousandRupeeNotes; }
            set { SetProperty(ref _thousandRupeeNotes, value); }
        }

        
    }
}
