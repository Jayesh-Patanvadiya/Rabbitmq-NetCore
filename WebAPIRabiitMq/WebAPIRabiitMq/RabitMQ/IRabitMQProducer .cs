namespace WebAPIRabiitMq.RabitMQ
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message, string routingKeyName);

        public void ReceiveProductMessage<T>(string routingKeyName);
    }
}
