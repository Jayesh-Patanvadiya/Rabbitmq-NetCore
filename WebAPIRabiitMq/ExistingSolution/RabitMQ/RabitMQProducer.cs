using Google.Api;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace RabitMqTestingAPI.RabitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        private readonly Collection<string> respQueue = new Collection<string>();

        public async Task<string> SendProductMessage<T>(T message, string routingKeyName)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: routingKeyName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);


                string messagetemp = Convert.ToString(message);
                var body = Encoding.UTF8.GetBytes(messagetemp);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "",
                                     routingKey: routingKeyName,
                                     basicProperties: properties,
                                     body: body);
                //Console.WriteLine(" [x] Sent {0}", message);

                return messagetemp;
            }


        }


        public async Task<Collection<string>> ReceiveProductMessage(string routingKeyName)
        {
            try
            {
                StringBuilder arrayList = new StringBuilder();
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())

                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: routingKeyName,
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                    //Console.WriteLine(" [*] Waiting for messages.");

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += async (sender, ea) =>
                    {


                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);



                        Console.WriteLine(" [x] Received {0}", message);

                        int dots = message.Split('.').Length - 1;
                        Thread.Sleep(dots * 1000);

                        Console.WriteLine(" [x] Done");

                        // Note: it is possible to access the channel via
                        //       ((EventingBasicConsumer)sender).Model here
                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

                        respQueue.Add(message);
                    };
                    channel.BasicConsume(queue: routingKeyName,
                                         autoAck: false,
                                         consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();

                }
                return respQueue;
            }
            catch(Exception ex)
            {
                return respQueue;
            }
        }



        public async Task<string> tempmethod(string test)
        {
           respQueue.Add(test);
            return test;
        }
    }
}
