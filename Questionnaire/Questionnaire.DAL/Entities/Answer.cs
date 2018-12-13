using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire.DAL.Entities
{
    [Table("Answer")]
    public class Answer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}