using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire.DAL.Entities
{
    [Table("Data")]
    public class Data
    {
        public short Id { get; set; }
        public int QuestionAnswerId { get; set; }
       
        public int FormId { get; set; }
      
        public string Comment { get; set; }
        
        public virtual QuestionAnswer QuestionAnswer { get; set; }
        public virtual Form Form { get; set; }
    }
}