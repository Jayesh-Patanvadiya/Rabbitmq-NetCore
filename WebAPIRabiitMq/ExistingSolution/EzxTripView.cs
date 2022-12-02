using System;
using System.Text.Json.Serialization;
using Google.Cloud.Firestore;

namespace Ezx.Models
{
    [FirestoreData]
    public partial class EzxTripView
    {
        [FirestoreDocumentId]
        [JsonPropertyName("TripPnr")]
        public string TripPnr { get; set; }
        //PickupEzPlaceId
        [FirestoreProperty]
        [JsonPropertyName("PickupLat")]
        public double? PickupLat { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("PickupLon")]
        public double? PickupLon { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("PickupSuburbId")]
        public int? PickupSuburbId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("PickupZoneId")]
        public int? PickupZoneId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("PickupDestinationId")]
        public int? PickupDestinationId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("PickupDisplayAddress")]
        public string PickupDisplayAddress { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("PickupEzPlaceId")]
        public string PickupEzPlaceId { get; set; }
        //DropOffEzPlaceId
        [FirestoreProperty]
        [JsonPropertyName("DropOffLat")]
        public double? DropOffLat { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("DropOffLon")]
        public double? DropOffLon { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("DropOffSuburbId")]
        public int? DropOffSuburbId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("DropOffZoneId")]
        public int? DropOffZoneId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("DropOffDestinationId")]
        public int? DropOffDestinationId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("DropOffDisplayAddress")]
        public string DropOffDisplayAddress { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("DropOffEzPlaceId")]
        public string DropOffEzPlaceId { get; set; }
        //Geo
        [FirestoreProperty]
        [JsonPropertyName("TripDistancePointToPoint")]
        public double TripDistancePointToPoint { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("TripCo2")]
        public double TripCo2 { get; set; }
        //PickupDT
        [FirestoreProperty]
        [JsonPropertyName("PickupDT")]
        public DateTime PickupDT { get; set; }
        //Equpment
        [FirestoreProperty]
        [JsonPropertyName("EquipmentVehicleTypeId")]
        public byte EquipmentVehicleTypeId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("EquipmentIncludeBabySeat")]
        public bool EquipmentIncludeBabySeat { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("EquipmentIncludeTrailer")]
        public bool EquipmentIncludeTrailer { get; set; }

        //Passenger
        [FirestoreProperty]
        [JsonPropertyName("PassengerFirstName")]
        public string PassengerFirstName { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("PassengerSurname")]
        public string PassengerSurname { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("PassengerEmail")]
        public string PassengerEmail { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("PassengerMobile")]
        public string PassengerMobile { get; set; }
        //EzxTripStatus
        [FirestoreProperty]
        [JsonPropertyName("EzxTripStatus")]
        public int? EzxTripStatus { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("EzxStatusUpdateDateTime")]
        public DateTime EzxStatusUpdateDateTime { get; set; }
        //FinanceStatus
        [FirestoreProperty]
        [JsonPropertyName("FinanceStatus")]
        public int? FinanceStatus { get; set; }
        //Payment
        [FirestoreProperty]
        [JsonPropertyName("PaymentType")]
        public int PaymentType { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("PaymentAmountInCents")]
        public int PaymentAmountInCents { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("PaymentCompleted")]
        public bool PaymentCompleted { get; set; }
        //Ref
        [FirestoreProperty]
        [JsonPropertyName("RefReservationId")]
        public int RefReservationId { get; set; }
        // [Key]
        [FirestoreProperty]
        [JsonPropertyName("RefTripId")]
        public int RefTripId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefGeTripId")]
        public string RefGeTripId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefPricePlanId")]
        public int RefPricePlanId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefDisplayPricePlanName")]
        public string RefDisplayPricePlanName { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefParentClientId")]
        public int RefParentClientId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefClientGroupId")]
        public int RefClientGroupId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefClientId")]
        public int RefClientId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefOfficeId")]
        public int RefOfficeId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefDispatchOfficeId")]
        public int RefDispatchOfficeId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefContactId")]
        public int RefContactId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefQuoteId")]
        public string RefQuoteId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefCreatedUserId")]
        public int RefCreatedUserId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefLastModifiedUserId")]
        public int RefLastModifiedUserId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefDriverId")]
        public int? RefDriverId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefOverRideAssignDriverId")]
        public int? RefOverRideAssignDriverId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefDisplayOverRideAssignDriverFirstname")]
        public string RefDisplayOverRideAssignDriverFirstname { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefDisplayOverRideAssignDriverSurname")]
        public string RefDisplayOverRideAssignDriverSurname { get; set; }
        //Commission
        [FirestoreProperty]
        [JsonPropertyName("DriverCommissionPercent")]
        public int? DriverCommissionPercent { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("ClientCommissionPercent")]
        public int ClientCommissionPercent { get; set; }
        //Invoice
        [FirestoreProperty]
        [JsonPropertyName("InvoiceNumber")]
        public int? InvoiceNumber { get; set; }
        //RefDisplay
        [FirestoreProperty]
        [JsonPropertyName("RefDisplayClientGroupName")]
        public string RefDisplayClientGroupName { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefDisplayParentClientName")]
        public string RefDisplayParentClientName { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefDisplayClientName")]
        public string RefDisplayClientName { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefDisplayOfficeName")]
        public string RefDisplayOfficeName { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefDisplayRequestedVehicleName")]
        public string RefDisplayRequestedVehicleName { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefDisplayDispatchOfficeName")]
        public string RefDisplayDispatchOfficeName { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefDisplayDriverFirstname")]
        public string RefDisplayDriverFirstname { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefDisplayDriverSurname")]
        public string RefDisplayDriverSurname { get; set; }
       
        [FirestoreProperty]
        [JsonPropertyName("DriverIsSubcontractor")]
        public bool? DriverIsSubcontractor { get; set; }

        [FirestoreProperty]
        [JsonPropertyName("RefDisplayDriverMobile")]
        public string RefDisplayDriverMobile { get; set; }

        [FirestoreProperty]
        [JsonPropertyName("RefDisplayCreatedUsername")]
        public string RefDisplayCreatedUsername { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefDisplayModifiedUsername")]
        public string RefDisplayModifiedUsername { get; set; }

        //Client
        [FirestoreProperty]
        [JsonPropertyName("ClientReference")]
        public string ClientReference { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("ClientPurchaseOrder")]
        public string ClientPurchaseOrder { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("ClientNotes")]
        public string ClientNotes { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("ClientPax")]
        public Int16 ClientPax { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("ClientFlightNumber")]
        public string ClientFlightNumber { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("ClientOverRideBlockDriverPeriodMinutes")]
        public int ClientOverRideBlockDriverPeriodMinutes { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("ClientPickupAddressNotes")]
        public string ClientPickupAddressNotes { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("ClientDropOffAddressNotes")]
        public string ClientDropOffAddressNotes { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("ClientAccountPhysicalAddress")]
        public string ClientAccountPhysicalAddress { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("ClientAccountReference")]
        public string ClientAccountReference { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("ClientCostCentre")]
        public string ClientCostCentre { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("ClientAccountTerms")]
        public string ClientAccountTerms { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("HasAccount")]
        public int HasAccount { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("RefKeyAccountsManagerId")]
        public int RefKeyAccountsManagerId { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("KeyAccountsManagerName")]
        public string KeyAccountsManagerName { get; set; }
        [FirestoreProperty]
        [JsonPropertyName("ParentKeyAccountsManagerName")]
        public string ParentKeyAccountsManagerName { get; set; }

        [FirestoreProperty]
        [JsonPropertyName("VoucherRequired")]
        public bool VoucherRequired { get; set; }
        
        [FirestoreProperty]
        [JsonPropertyName("ClientInvoiceReservation")]
        public bool ClientInvoiceReservation { get; set; }

        [FirestoreProperty]
        [JsonPropertyName("CustomFieldJson")]
        public string CustomFieldJson { get; set; }

        //Record
        [FirestoreProperty]
        [JsonPropertyName("RecordCreateUtc")]
        public DateTime RecordCreateUtc { get; set; }
        
        [FirestoreProperty]
        [JsonPropertyName("RecordModifiedUtc")]
        public DateTime RecordModifiedUtc { get; set; }
    }
}
