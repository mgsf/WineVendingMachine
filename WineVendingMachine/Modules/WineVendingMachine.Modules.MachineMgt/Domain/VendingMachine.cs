using System;
using System.Collections.Generic;
using System.Linq;
using WineVendingMachine.Core.Framework;
using static WineVendingMachine.Modules.MachineMgt.Domain.Money;

namespace WineVendingMachine.Modules.MachineMgt.Domain
{
    public class VendingMachine : AggregateRoot
    {
        public virtual Money MoneyInMachine { get; protected set; } 
 

        public VendingMachine()
        {
            MoneyInMachine = None;
            
        }

        public virtual void InsertMoney(Money money) 
        {
            MoneyInMachine += money;
        }


        public virtual void LoadMoney(Money money) 
        {
            MoneyInMachine += money;
        }

        /*
       

        public void UnLoadMoney() { }

        public void LoadWine() { } */


    }
}
