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
        public virtual IList<Channel> Channels { get; }

        public VendingMachine()
        {
            MoneyInMachine = None;
            MoneyInTransaction = 0.00m;
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
        
        public virtual bool WineAvailable(int channel)
        {
            bool channelQuantity =  Channels.SingleOrDefault(x => x.ChannelID.Equals(channel)).Quantity > 0;
           
            return channelQuantity;
        }

        public virtual void BuyWine(int channel) 
        {
            var obj = Channels.SingleOrDefault(x => x.ChannelID.Equals(channel));
            if ( MoneyInTransaction > obj.Price)
            {
                //1-Reduce channel quantity
                obj.Quantity--;
                //2-Return balance
                Money balance = MoneyInMachine.AllocateMoney(MoneyInTransaction - obj.Price);
                MoneyInMachine -= balance;
                //3-Make money in transaction zero
                MoneyInTransaction = 0;
            }
        } 



        /*
        public void LoadMoney() { }

        public void UnLoadMoney() { }

        public void LoadWine() { } */


    }
}
