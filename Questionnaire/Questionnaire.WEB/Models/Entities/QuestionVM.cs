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
        public short QuestionTypeId { get; set; }

        [Display(Name = "Вопрос")]
        [StringLength(1000, ErrorMessage = "Длина строки не должна превышать 1000 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Name { get; set; }

        public QuestionTypeDTO QuestionType { get; set; }
        public ICollection<QuestionAnswerDTO> QuestionAnswers { get; set; }
    }
}