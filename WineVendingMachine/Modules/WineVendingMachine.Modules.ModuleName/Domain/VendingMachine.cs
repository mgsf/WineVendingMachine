using System;
using System.Collections.Generic;
using System.Linq;
using WineVendingMachine.Core.Framework;
using static WineVendingMachine.Modules.SellWine.Domain.Money;

namespace WineVendingMachine.Modules.SellWine.Domain
{
    public class VendingMachine : AggregateRoot
    {
        public virtual Money MoneyInMachine { get; protected set; } 
        public virtual decimal MoneyInTransaction { get; protected set; } 

        public VendingMachine()
        {
            MoneyInMachine = None;
            MoneyInTransaction = 0;
        }

        public virtual void InsertMoney(Money money) 
        {
            Money[] Notes = {TenRupee, TwentyRupee, FiftyRupee, HundredRupee, FiveHundredRupee, ThousandRupee };
            if (!Notes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money.Amount;
            MoneyInMachine += money;
        }


        public virtual void ReturnMoney()
        {
            Money moneyReturn = MoneyInMachine.AllocateMoney(MoneyInTransaction);
            MoneyInMachine -= moneyReturn;
            MoneyInTransaction = 0.00m;
        }
        
        public virtual void BuyWine() 
        {
            
        } 



        /*
        public void LoadMoney() { }

        public void UnLoadMoney() { }

        public void LoadWine() { } */


    }
}
