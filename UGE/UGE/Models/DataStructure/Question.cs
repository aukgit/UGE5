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
    
    public partial class Question
    {
        public Question()
        {
            this.Choices = new HashSet<Choice>();
            this.MistakeQuestions = new HashSet<MistakeQuestion>();
        }
    
        public long QuestionID { get; set; }
        public string Hint { get; set; }
        public long AnswerChoiceID { get; set; }
        public string QuestionDisplay { get; set; }
        public int MCQID { get; set; }
    
        public virtual ICollection<Choice> Choices { get; set; }
        public virtual Choice Choice { get; set; }
        public virtual MCQ MCQ { get; set; }
        public virtual ICollection<MistakeQuestion> MistakeQuestions { get; set; }
    }
}
