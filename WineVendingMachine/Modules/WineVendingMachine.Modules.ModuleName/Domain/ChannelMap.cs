using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WineVendingMachine.Modules.SellWine.Domain
{
    public class ChannelMap : ClassMap<Channel>
    {
        public ChannelMap()
        {
            CompositeId()
                .KeyProperty(x => x.ChannelID, "ChannelID")
                .KeyProperty(x => x.VendingMachineID, "VendingMachineID");


            Map(x => x.Quantity)
                .Not.Nullable();

            Map(x => x.Price)
                .Not.Nullable();


            References(x => x.Wine)
                .Not.LazyLoad();

               
        }
    }
}
