using Prism.Events;
using WineVendingMachine.Core.Events.Models;

namespace WineVendingMachine.Core.Events
{
    public class MoneyLoadedEvent : PubSubEvent<Money>
    {
    }
}
