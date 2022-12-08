using Ezx.Core.Hub;
using Ezx.Models;
using RabitMqTestingAPI.RabitMQ;
using StackExchange.Redis;
using System;
using System.Collections;
using System.Text;

namespace ExistingSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            testc();
        }

        public static async void testc()
        {
            ArrayList stringBuilder = new ArrayList();
            RabitMQProducer _rabitMQProducer = new RabitMQProducer();
            //Console.WriteLine("Hello World!");
            EzMessageHub ezMessageHub = new EzMessageHub(_rabitMQProducer);

            EzxTripView ezxTripView = new EzxTripView()
            {
                TripPnr = "test 333"
            };
            await ezMessageHub.OnTripCreated(ezxTripView);

            //ezMessageHub.Subscribe();
        }

    }
}
