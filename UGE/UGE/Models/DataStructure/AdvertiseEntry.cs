//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UGE.Models.DataStructure
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdvertiseEntry
    {
        public AdvertiseEntry()
        {
            this.Links = new HashSet<Link>();
        }
    
        public long AdvertiseEntryID { get; set; }
        public string AdvertiseName { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public bool IsPublishedDateOver { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public decimal OfferToPayFor { get; set; }
        public bool IsAccepted { get; set; }
        public int AdvertisePlacedByUserID { get; set; }
        public Nullable<int> AcceptedByUserID { get; set; }
        public Nullable<long> PaymentID { get; set; }
        public bool IsPaymentSuccessful { get; set; }
    
        public virtual Payment Payment { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual ICollection<Link> Links { get; set; }
    }
}
