using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQ_Queue
{
    //NewTask
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "task_queue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = GetMessage(args);
                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "",
                                     routingKey: "task_queue",
                                     basicProperties: properties,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
            ////Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            //var factory = new ConnectionFactory
            //{
            //    HostName = "localhost"
            //};
            ////Create the RabbitMQ connection using connection factory details as i mentioned above
            //var connection = factory.CreateConnection();
            ////Here we create channel with session and model

            //var channel = connection.CreateModel();
            ////declare the queue after mentioning name and a few property related to that
            //channel.QueueDeclare("product", exclusive: false);
            ////Set Event object which listen message from chanel which is sent by producer
            //var consumer = new EventingBasicConsumer(channel);
            //consumer.Received += (model, eventArgs) => {
            //    var body = eventArgs.Body.ToArray();
            //    var message = Encoding.UTF8.GetString(body);
            //    Console.WriteLine($"Product message received: {message}");
            //};
            ////read the message
            //channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);
            //Console.ReadKey();

        }
        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
