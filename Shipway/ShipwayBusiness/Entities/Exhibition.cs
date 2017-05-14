using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities
{
    public class Exhibition
    {
        public string ExhibitionId { get; set; }
        public string SenderName { get; set; }
        public string SenderPhoneNumber { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public string ReceiverAddress { get; set; }
        public int PackageWeigh { get; set; }
        public int PackageLong { get; set; }
        public int PackageWide { get; set; }
        public int PackageHigh { get; set; }
        public int NoteRequiredId { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LasrModifiedUserId { get; set; }
        public int KindServiceId { get; set; }
        public int Cost { get; set; }
        public int AssignShipperId { get; set; }
        public int ExhibitionStatusId { get; set; }
        public bool IsSendToAgency { get; set; }
        public DateTime? DayReceive { get; set; }
        public string LocationSender { get; set; }
        public string LocationReceive { get; set; }
        public int? AssignToAgency { get; set; }
    }

    public class ExhibitionView
    {
        public string ExhibitionId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Cost { get; set; }
        public string ExhibitionStatus { get; set; }
    }

    public class ExhibitionViewModel
    {
        public Exhibition Exhibition { get; set; }
        public string ExhibitonStatus { get; set; }
    }
}