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

        [Display(Name = "ФИО Респондента")]
        [StringLength(100, ErrorMessage = "Длина строки не должна превышать 100 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Name { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Заполните поле!")]
        public Gender Sex { get; set; }

        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Заполните поле!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateBorn { get; set; }

        [Display(Name = "Возраст/Лет")]
        public short Age { get; set; }

        [Display(Name = "Номер анкеты")]
        [Required(ErrorMessage = "Необходимо выбрать опросник!")]
        public int FormId { get; set; }
        public FormDTO Form { get; set; }
    }
}