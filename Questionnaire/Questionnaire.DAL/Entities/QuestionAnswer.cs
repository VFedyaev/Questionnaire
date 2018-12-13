using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire.DAL.Entities
{
    [Table("QuestionAnswer")]
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }      
        public int AnswerId { get; set; }

        public virtual Question Question { get; set; }
        public virtual Answer Answer { get; set; }
    }
}