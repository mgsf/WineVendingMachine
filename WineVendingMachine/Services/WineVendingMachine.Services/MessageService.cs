using WineVendingMachine.Services.Interfaces;

namespace WineVendingMachine.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
