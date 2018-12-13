using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire.DAL.Entities
{
    [Table("Question")]
    public class Question
    {
        public int Id { get; set; }
        public short QuestionTypeId { get; set; }
        public string Name { get; set; }

        public virtual QuestionType QuestionType { get; set; }
    }
}