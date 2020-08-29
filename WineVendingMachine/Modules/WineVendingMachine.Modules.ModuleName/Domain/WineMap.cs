using FluentNHibernate.Mapping;


namespace WineVendingMachine.Modules.SellWine.Domain
{
    public class WineMap : ClassMap<Wine>
    {
        public WineMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
        }
    }
}
