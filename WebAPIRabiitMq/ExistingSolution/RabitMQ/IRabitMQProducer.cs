using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RabitMqTestingAPI.RabitMQ
{
    public interface IRabitMQProducer
    {
        public Task<string> SendProductMessage<T>(T message, string routingKeyName);

        Task<Collection<string>> ReceiveProductMessage(string routingKeyName);
    }
}
