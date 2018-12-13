using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire.DAL.Entities
{
    [Table("Interviewer")]
    public class Interviewer
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}