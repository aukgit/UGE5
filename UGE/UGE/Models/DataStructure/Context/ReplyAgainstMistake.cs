//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication6.Models.DataStructure
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReplyAgainstMistake
    {
        public ReplyAgainstMistake()
        {
            this.ReplyAgainstMistake1 = new HashSet<ReplyAgainstMistake>();
        }
    
        public long ReplyAgainstMistakeID { get; set; }
        public long ArticleMistakeID { get; set; }
        public int RepliedByWhomID { get; set; }
        public string Reply { get; set; }
        public long LinkedReplyMistakeID { get; set; }
    
        public virtual ArticleMistake ArticleMistake { get; set; }
        public virtual ICollection<ReplyAgainstMistake> ReplyAgainstMistake1 { get; set; }
        public virtual ReplyAgainstMistake ReplyAgainstMistake2 { get; set; }
    }
}
