using Ezx.Core.Hub;
using Ezx.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultipleListerner.ExistingProject
{
    public interface IEzMessageHub
    {


        //fire events
        Task<bool> OnTripCreated(EzxTripView tqv);
        Task<bool> OnTripModified(EzxTripView tqv, UpdateFieldResult[] updateFieldResults);

        Task<bool> OnTripCancelled(EzxTripView tqv);

        //events
        event System.EventHandler<OnTripCreateMessage> OnTripCreatedEvent;
        event System.EventHandler<OnTripModifiedMessage> OnTripModifiedEvent;
        event System.EventHandler<OnTripCancelledMessage> OnTripCancelledEvent;
     

        event System.EventHandler<OnConfirmationResendMessage> OnConfirmationResendEvent;
    }
}
