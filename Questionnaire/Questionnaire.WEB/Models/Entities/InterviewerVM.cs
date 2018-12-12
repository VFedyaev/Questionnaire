using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Entities
{
    public class InterviewerVM
    {
        public short Id { get; set; }

        [Display(Name = "ФИО Интервьюера")]
        [StringLength(100, ErrorMessage = "Длина строки не должна превышать 100 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Name { get; set; }

        [Display(Name = "Контактный телефон")]
        [StringLength(30, ErrorMessage = "Длина строки не должна превышать 30 символов")]
        public string Phone { get; set; }
    }
}