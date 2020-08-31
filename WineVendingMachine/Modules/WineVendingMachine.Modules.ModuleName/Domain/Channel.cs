using WineVendingMachine.Core.Framework;

namespace WineVendingMachine.Modules.SellWine.Domain
{
    public class Channel : Entity
    {
        public virtual int ChannelID { get; protected set; }
        public virtual int VendingMachineID { get; protected set; }
        //public virtual VendingMachine VendingMachine { get; protected set; }
        public virtual decimal Price { get; set; }
        public virtual int Quantity { get; set; }
        public virtual Wine Wine { get; set; }



        protected Channel()
        {
        }

        public Channel(int channelID, int vendingMachineID, Wine wine, decimal price, int quantity)
            :this()
        {
            ChannelID = channelID;
            VendingMachineID = vendingMachineID;
            Wine = wine;
            Price = price;
            Quantity = quantity;
        }
    }
}
