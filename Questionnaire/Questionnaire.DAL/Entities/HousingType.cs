using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire.DAL.Entities
{
    [Table("HousingType")]
    public class HousingType
    {
        public short Id { get; set; }
        public string Name { get; set; }
    }
}