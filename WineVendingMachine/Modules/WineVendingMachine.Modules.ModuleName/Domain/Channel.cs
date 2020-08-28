using WineVendingMachine.Core.Framework;

namespace WineVendingMachine.Modules.SellWine.Domain
{
    public class Channel : Entity
    {
        public virtual int ChannelID { get; protected set; }
        public virtual VendingMachine VendingMachine { get; protected set; }
        public virtual Wine Wine { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Quantity { get; set; }


        protected Channel()
        {
        }

        public Channel(int channelID, VendingMachine vendingMachine, Wine wine, decimal price, int quantity)
            :this()
        {
            ChannelID = channelID;
            VendingMachine = vendingMachine;
            Wine = wine;
            Price = price;
            Quantity = quantity;
        }
    }
}
