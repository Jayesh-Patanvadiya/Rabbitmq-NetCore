using System;

namespace Ezx.Models
{
    public class UpdateFieldResult
    {
        public UpdateFieldResult()
        {

        }

        public UpdateFieldResult(FieldNameEnum fieldName, ResultCodeEnum resultCode, string resultMessage, string oldValue = null, string newValue = null, SecondaryField[] secondaryFields = null)
        {
            FieldName = Enum.GetName(typeof(FieldNameEnum), fieldName);
            ResultCode = (int)resultCode;
            ResultMessage = resultMessage;
            if (secondaryFields == null)
            {
                SecondaryFields = new SecondaryField[0];
            }
            else
            {
                SecondaryFields = secondaryFields;
            }

            if (resultCode == ResultCodeEnum.UpdateResultOk)
            {
                if (oldValue != null)
                {
                    OldValueAudit = oldValue;
                }
                else
                {
                    OldValueAudit = "Value Not Defined";
                }

                if (newValue != null)
                {
                    NewValueAudit = newValue;
                }
                else
                {
                    NewValueAudit = "Value Not Defined";
                }
            }
        }

        public string FieldName { get; set; }
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }

        public string OldValueAudit { get; set; }
        public string NewValueAudit { get; set; }

        public SecondaryField[] SecondaryFields { get; set; }
    }

    public class SecondaryField
    {
        public SecondaryField()
        {

        }
        
        public SecondaryField(string fieldName, string oldValue, string newValue)
        {
            FieldName = fieldName;
            OldValueAudit = oldValue;
            NewValueAudit = newValue;
        }

        public string FieldName { get; set; }
        public string OldValueAudit { get; set; }
        public string NewValueAudit { get; set; }
    }

    public enum FieldNameEnum
    {
        PickupAddressNotes,
        DropOffAddressNotes,
        PaymentType,
        PaymentCompleted,
        RefContactId,
        RefQuoteId,
        RefDriverId,
        ClientNotes,
        ClientPurchaseOrder,
        ClientFlightNumber,
        ClientPax,
        RefPricePlanId,
        RefOverRideAssignDriverId,
        ClientOverRideBlockDriverPeriodMinutes,
        EquipmentVehicleTypeId,
        EquipmentIncludeBabySeat,
        EquipmentIncludeTrailer,
        FinanceStatus,
        EzxStatus,
        InvoiceNumber
    }

    public enum ResultCodeEnum
    {
        UpdateResultOk = 0,
        UpdateResultError = 1,
        UpdateResultNoChange = 3
    }

    public static class ResultMessageConst
    {
        public static string Ok = "Updated OK";
        public static string NoChange = "Field not updated as there was no change in value";

        public static string FailedErrorDB = "Field not updated as there was a database error";
    }
}
