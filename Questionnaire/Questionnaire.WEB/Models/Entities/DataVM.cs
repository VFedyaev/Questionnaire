using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Entities
{
    public class DataVM
    {
        public short Id { get; set; }

        public int QuestionAnswerId { get; set; }
        public QuestionAnswerDTO QuestionAnswer { get; set; }

        public int FormId { get; set; }
        public FormDTO Form { get; set; }

        [Display(Name = "Другое...")]
        [StringLength(300, ErrorMessage = "Длина строки не должна превышать 300 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Comment { get; set; }
    }
}