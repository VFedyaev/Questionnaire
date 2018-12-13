using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire.DAL.Entities
{
    [Table("SurveyGeographies")]
    public class SurveyGeography
    {
        public short Id { get; set; }
        public string Name { get; set; }
    }
}