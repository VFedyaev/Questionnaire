using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Entities
{
    public class Question
    {
        public int Id { get; set; }

        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }

        [Display(Name = "Вопрос")]
        [StringLength(1000, ErrorMessage = "Длина строки не должна превышать 1000 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Name { get; set; }

        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}