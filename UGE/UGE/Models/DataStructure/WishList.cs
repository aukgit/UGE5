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
    
    public partial class WishList
    {
        public long WishListID { get; set; }
        public int UserID { get; set; }
        public long ArticleID { get; set; }
        public System.DateTime Dated { get; set; }
        public System.DateTime LastNotified { get; set; }
    
        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }
}
