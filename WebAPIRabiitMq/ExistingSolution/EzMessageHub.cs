using Ezx.Models;
using MultipleListerner.ExistingProject;
using RabitMqTestingAPI.RabitMQ;
using Silmac.Core.Infrastructure;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ezx.Core.Hub
{
    public class EzMessageHub : IEzMessageHub
    {
        //IConnectionMultiplexer _connectionMultiplexer;
        //ISubscriber _subscriber { get; set; }

        IRabitMQProducer _rabitMQProducer;

        static string _serviceName = Environment.GetEnvironmentVariable("EZX_SERVICENAME");

        public EzMessageHub(IRabitMQProducer rabitMQProducer)
        {
            //_connectionMultiplexer = connectionMultiplexer;
            //_subscriber = _connectionMultiplexer.GetSubscriber();
            _rabitMQProducer = rabitMQProducer;
             Subscribe();
           
        }
        public  void Subscribe()
        {
            if (onTripCreatedEvent != null)
            {
                //onTripCreatedEvent.Invoke(this, msg);
               _rabitMQProducer.ReceiveProductMessage("OnTripCreate");
            }
            if (onTripModifiedEvent != null)
            {
                _rabitMQProducer.ReceiveProductMessage("OnTripModified");
            }
           
            if (onTripCancelledEvent != null)
            {
                _rabitMQProducer.ReceiveProductMessage("OnTripCancelled");
            }

            //_subscriber.Subscribe(EzMessageHubMessageType.TripCreate.ToString(), async (channel, json) =>
            //{
            //    var msg = await JsonHelper.DeserializeAsync<OnTripCreateMessage>(json);
            //    if (onTripCreatedEvent != null)
            //    {
            //        onTripCreatedEvent.Invoke(this, msg);
            //    }

            //    _rabitMQProducer.ReceiveProductMessage<OnTripCreateMessage>("OnTripCreate");

            //});

            //_subscriber.Subscribe(EzMessageHubMessageType.TripModify.ToString(), async (channel, json) =>
            //{
            //    var msg = await JsonHelper.DeserializeAsync<OnTripModifiedMessage>(json);
            //    if (onTripModifiedEvent != null)
            //    {
            //        onTripModifiedEvent.Invoke(this, msg);
            //    }
            //    _rabitMQProducer.ReceiveProductMessage<OnTripModifiedMessage>("OnTripModified");

            //});




            //_subscriber.Subscribe(EzMessageHubMessageType.TripCancel.ToString(), async (channel, json) =>
            //{
            //    var msg = await JsonHelper.DeserializeAsync<OnTripCancelledMessage>(json);
            //    if (onTripCancelledEvent != null)
            //    {
            //        onTripCancelledEvent.Invoke(this, msg);
            //    }

            //    _rabitMQProducer.ReceiveProductMessage<OnTripCancelledMessage>("OnTripCancelled");
            //});


        }

        // TripCreate
        // TripModify
        // TripCancel
        // DriverChange
        // TripReminder1
        // TripReminder2
        // TripReminder3
        // TripSurvey
        // SimpleTextMessage
        // DriverHeartbeatMessage
        // EzxRealtimeTripViewChangeMessage
        // InvoiceCreate
        // OnSmtpEmail_Paygate
        // OnVoucherReminderMessage
        // OnConfirmationResendMessage

        //implemented rabitMQ here
        public async Task<bool> OnTripCreated(EzxTripView tqv)
        {
            var msg = new OnTripCreateMessage();
            msg.EzxTripView = tqv;
            var json = await JsonHelper.SerializeAsync<OnTripCreateMessage>(msg);

            //var database = _connectionMultiplexer.GetDatabase();
            //await database.PublishAsync(EzMessageHubMessageType.TripCreate.ToString(), json);

           // var jsonDes = await JsonHelper.DeserializeAsync<OnTripCreateMessage>(json);

            // RabitMQ Implementation
            await   _rabitMQProducer.SendProductMessage(json, "OnTripCreated");
            var temp =  await _rabitMQProducer.ReceiveProductMessage("OnTripCreated");
            return  true;
        }

        //implemented rabitMQ here
        public async Task<bool> OnTripModified(EzxTripView tqv, UpdateFieldResult[] updateFieldResults)
        {
            var msg = new OnTripModifiedMessage();
            msg.EzxTripView = tqv;
            msg.UpdateFieldResult = updateFieldResults;
            var json = await JsonHelper.SerializeAsync<OnTripModifiedMessage>(msg);

            //var database = _connectionMultiplexer.GetDatabase();
            //await database.PublishAsync(EzMessageHubMessageType.TripModify.ToString(), json);


            var driverChangeResult = updateFieldResults.ToList().Where(i => i.FieldName == FieldNameEnum.RefDriverId.ToString() && i.ResultCode == (int)ResultCodeEnum.UpdateResultOk).SingleOrDefault();
            //if (driverChangeResult != null)
            //{
            //    int oldDriverId;
            //    if (int.TryParse(driverChangeResult.OldValueAudit, out oldDriverId))
            //    {
            //        if (oldDriverId != -1 && oldDriverId != 0)
            //        {
            //            await database.PublishAsync(_serviceName + EzMessageHubMessageType.DriverChange.ToString() + "_" + oldDriverId.ToString(), json);
            //        }
            //    };

            //    //int newDriverId;
            //    //if (int.TryParse(driverChangeResult.OldValueAudit, out newDriverId))
            //    //{
            //    //    if (newDriverId != -1 && newDriverId != 0)
            //    //    {
            //    //        await database.PublishAsync(_serviceName + EzMessageHubMessageType.DriverChange.ToString() + "_" + newDriverId.ToString(), json);
            //    //    }
            //    //};
            //}



            // RabitMQ Implementation
            _rabitMQProducer.SendProductMessage(json, "OnTripModified");

            

            return true;
        }
        //implemented rabitMQ here
        public async Task<bool> OnTripCancelled(EzxTripView tqv)
        {
            var msg = new OnTripCancelledMessage();
            msg.EzxTripView = tqv;
            var json = await JsonHelper.SerializeAsync<OnTripCancelledMessage>(msg);

            //var database = _connectionMultiplexer.GetDatabase();
            //await database.PublishAsync(EzMessageHubMessageType.TripCancel.ToString(), json);

            // RabitMQ Implementation
            _rabitMQProducer.SendProductMessage(json, "OnTripCancelled");
            
            return true;
        }



        //Events
        public event EventHandler<OnTripCreateMessage> OnTripCreatedEvent
        {
            add { onTripCreatedEvent += value; }
            remove { onTripCreatedEvent -= value; }
        }
        private EventHandler<OnTripCreateMessage> onTripCreatedEvent;

        public event EventHandler<OnTripModifiedMessage> OnTripModifiedEvent
        {
            add { onTripModifiedEvent += value; }
            remove { onTripModifiedEvent -= value; }
        }
        private EventHandler<OnTripModifiedMessage> onTripModifiedEvent;

        public event EventHandler<OnConfirmationResendMessage> OnConfirmationResendEvent
        {
            add { onConfirmationResendEvent += value; }
            remove { onConfirmationResendEvent -= value; }
        }
        private EventHandler<OnConfirmationResendMessage> onConfirmationResendEvent;
        
        
        public event EventHandler<OnTripCancelledMessage> OnTripCancelledEvent
        {
            add { onTripCancelledEvent += value; }
            remove { onTripCancelledEvent -= value; }
        }
        private EventHandler<OnTripCancelledMessage> onTripCancelledEvent;



    }

    public class OnTripCreateMessage : EzMessageHubMessageBase
    {
        public OnTripCreateMessage() : base()
        {

        }

        public EzxTripView EzxTripView { get; set; }
    }

    public class OnTripModifiedMessage : EzMessageHubMessageBase
    {
        public OnTripModifiedMessage() : base()
        {

        }

        public EzxTripView EzxTripView { get; set; }
        public UpdateFieldResult[] UpdateFieldResult { get; set; }
    }

    public class OnTripCancelledMessage : EzMessageHubMessageBase
    {
        public OnTripCancelledMessage() : base()
        {

        }

        public EzxTripView EzxTripView { get; set; }
    }

    

    public partial class OnConfirmationResendMessage : EzMessageHubMessageBase
    {
        [JsonPropertyName("EzxTripView")]
        public EzxTripView EzxTripView { get; set; }

        [JsonPropertyName("IsEmail")]
        public bool IsEmail { get; set; }

        [JsonPropertyName("IsMobile")]
        public bool IsMobile { get; set; }
    }


    public class EzMessageHubMessageBase
    {
        public EzMessageHubMessageBase()
        {
            SourceServiceName = Environment.GetEnvironmentVariable("EZX_SERVICENAME");
        }

        public string SourceServiceName { get; set; }
        public Guid? MessageId { get; set; }

        public int? UserId { get; set; }
        public int? UserClientId { get; set; }
        public string Username { get; set; }
        public string UserRole { get; set; }
    }


    public enum EzMessageHubMessageType
    {
        TripCreate,
        TripModify,
        TripCancel,
        DriverChange,
        TripReminder1,
        TripReminder2,
        TripReminder3,
        TripSurvey,
        SimpleTextMessage,
        DriverHeartbeatMessage,
        EzxRealtimeTripViewChangeMessage,
        InvoiceCreate,
        OnSmtpEmail_Paygate,
        OnVoucherReminderMessage,
        OnConfirmationResendMessage
    }

}
