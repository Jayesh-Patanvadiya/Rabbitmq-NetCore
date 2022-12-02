using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace WebAPIRabiitMq.RabitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendProductMessage<T>(T message,string routingKeyName)
        {
            
            //Here we specify the Rabbit MQ Server. 
            var factory = new ConnectionFactory() { HostName = "localhost" };
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            using (var connection = factory.CreateConnection())
            //Here we create channel with session and model
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                //put the data on to the  queue
                channel.BasicPublish(exchange: "logs",
                                     routingKey: routingKeyName,
                                     basicProperties: null,
                                     body: body);
            }
        }

        public void ReceiveProductMessage<T>(string routingKeyName)
        {
            //Here we specify the Rabbit MQ Server. 
            var factory = new ConnectionFactory() { HostName = "localhost" };
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            using (var connection = factory.CreateConnection())

            //Here we create channel with session and model

            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName,
                                  exchange: "logs",
                                  routingKey: routingKeyName);


                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);
            }
        }
    }
}
