using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire.DAL.Entities
{
    [Table("QuestionType")]
    public class QuestionType
    {
        public short Id { get; set; }
        public string Name { get; set; }
    }
}