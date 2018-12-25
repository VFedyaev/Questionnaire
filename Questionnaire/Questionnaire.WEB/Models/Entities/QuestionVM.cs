using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Entities
{
    public class QuestionVM
    {
        public int Id { get; set; }

        [Display(Name = "Тип вопроса")]
        public short QuestionTypeId { get; set; }

        [Display(Name = "Вопрос")]
        [StringLength(1000, ErrorMessage = "Длина строки не должна превышать 1000 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Name { get; set; }

        [Display(Name = "Вопрос может содержать несколько ответов")]
        public bool MultipleAnswer { get; set; }

        public QuestionTypeDTO QuestionType { get; set; }
        public ICollection<QuestionAnswerDTO> QuestionAnswers { get; set; }
    }
}