using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Entities
{
    public class HousingTypeVM
    {
        public short Id { get; set; }

        [Display(Name = "Тип жилья")]
        [StringLength(100, ErrorMessage = "Длина строки не должна превышать 100 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Name { get; set; }

        public ICollection<FormDTO> Forms { get; set; }
    }
}