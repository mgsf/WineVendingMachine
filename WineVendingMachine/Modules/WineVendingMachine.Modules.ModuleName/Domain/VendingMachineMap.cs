﻿using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace WineVendingMachine.Modules.SellWine.Domain
{
    public class VendingMachineMap : ClassMap<VendingMachine>
    {
        public VendingMachineMap() 
        {
            Id(x => x.Id);

            Component(x => x.MoneyInMachine, y =>
            {
                y.Map(x => x.TenRupeeCount);
                y.Map(x => x.TwentyRupeeCount);
                y.Map(x => x.FiftyRupeeCount);
                y.Map(x => x.HundredRupeeCount);
                y.Map(x => x.FiveHundredRupeeCount);
                y.Map(x => x.ThousandRupeeCount);
            });

            HasMany<Channel>(Reveal.Member<VendingMachine>("Channels"))
                .Cascade.SaveUpdate()
                .Not.LazyLoad()
                .Inverse();
        }
    }
}
