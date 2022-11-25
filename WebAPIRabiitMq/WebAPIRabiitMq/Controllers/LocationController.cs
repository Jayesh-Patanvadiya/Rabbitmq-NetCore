using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using WebAPIRabiitMq.Model;
using WebAPIRabiitMq.RabitMQ;

namespace WebAPIRabiitMq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IRabitMQProducer _rabitMQProducer;

        public LocationController(IRabitMQProducer rabitMQProducer)
        {
            _rabitMQProducer = rabitMQProducer;
        }
        [HttpPost]
        public void Post([FromBody] Location location)
        {
            _rabitMQProducer.SendProductMessage(location);
        }
    }
}
