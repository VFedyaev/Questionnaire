using Questionnaire.BLL.DTO;
using Questionnaire.WEB.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Entities
{
    public class FamilyVM
    {
        public int Id { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Заполните поле!")]
        public Gender Sex { get; set; }

        [Range(18, 100)]
        [Display(Name = "Возраст/Лет")]
        public short Age { get; set; }

        [Display(Name = "Номер анкеты")]
        [Required(ErrorMessage = "Необходимо выбрать опросник!")]
        public int FormId { get; set; }
        public FormDTO Form { get; set; }
    }
}