using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static WineVendingMachine.Modules.SellWine.Domain.Money;

namespace WineVendingMachine.Modules.SellWine.Domain
{
    public sealed class VendingMachine : Entity
    {
        public Money MoneyInMachine { get; private set; } = None;
        public Money MoneyInTransaction { get; private set; } = None;

        public void InsertMoney(Money money) 
        {
            Money[] Notes = {TenRupee, TwentyRupee, FiftyRupee, HundredRupee, FiveHundredRupee, ThousandRupee };
            if(!Notes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public void SellWine() 
        {
            MoneyInMachine += MoneyInTransaction;
            MoneyInTransaction = None;
        }

        public void ReturnMoney() 
        {
            MoneyInTransaction = None;
        }

        public void LoadMoney() { }

        public void UnLoadMoney() { }

        public void LoadWine() { }
 

    }
}
