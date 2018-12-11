using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire.DAL.Entities
{
    [Table("District")]
    public class District
    {
        public short Id { get; set; }
        public string Name { get; set; }      
    }
}