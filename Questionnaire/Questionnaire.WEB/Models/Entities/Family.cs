using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Entities
{
    public class Family
    {
        public int Id { get; set; }

        [Display(Name = "ФИО Респондента")]
        [StringLength(100, ErrorMessage = "Длина строки не должна превышать 100 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Name { get; set; }

        [Display(Name = "Пол")]
        [StringLength(10, ErrorMessage = "Длина строки не должна превышать 10 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Sex { get; set; }

        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Заполните поле!")]
        public DateTime DateBorn { get; set; }

        [Display(Name = "Возраст/Лет")]
        public short Age { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать опросник!")]
        public int FormId { get; set; }
        public Form Form { get; set; }
    }
}