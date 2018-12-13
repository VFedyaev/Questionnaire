using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire.DAL.Entities
{
    [Table("Family")]
    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime DateBorn { get; set; }
        public short Age { get; set; }
        public int FormId { get; set; }

        public virtual Form Form { get; set; }
    }
}