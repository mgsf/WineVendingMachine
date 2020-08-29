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

        }

        public virtual void InsertMoney(Money money) 
        {
            Money[] Notes = {TenRupee, TwentyRupee, FiftyRupee, HundredRupee, FiveHundredRupee, ThousandRupee };
            if(!Notes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money.Amount;
            MoneyInMachine += money;
        }

        /*
        public void SellWine() 
        {
            
            
        } 

        public virtual void  ReturnMoney() 
        {
            
        }

        
        public void LoadMoney() { }

        public void UnLoadMoney() { }

        public void LoadWine() { } */
 

    }
}
