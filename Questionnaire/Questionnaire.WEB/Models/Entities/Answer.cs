using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Entities
{
    public class Answer
    {
        public int Id { get; set; }

        [Display(Name = "Ответ")]
        [StringLength(300, ErrorMessage = "Длина строки не должна превышать 300 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Name { get; set; }

        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}