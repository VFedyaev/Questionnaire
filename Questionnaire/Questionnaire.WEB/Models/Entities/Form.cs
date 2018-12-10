using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Entities
{
    public class Form
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать место проведения опроса!")]
        public int SurveyGeographyId { get; set; }
        public SurveyGeography SurveyGeography { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать тип жилья!")]
        public int HousingTypeId { get; set; }
        public HousingType HousingType { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать район!")]
        public int DistrictId { get; set; }
        public District District { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать интерьюера!")]
        public int InterviewerId { get; set; }
        public Interviewer Interviewer { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(300, ErrorMessage = "Длина строки не должна превышать 300 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Address { get; set; }

        [Display(Name = "Контактный телефон")]
        [StringLength(30, ErrorMessage = "Длина строки не должна превышать 30 символов")]
        public string Phone { get; set; }
   
        [Display(Name = "Дата проведения интервью")]
        [Required(ErrorMessage = "Заполните поле!")]
        public DateTime InterviewDate { get; set; }

        [Display(Name = "Время начала интервью")]
        [Required(ErrorMessage = "Заполните поле!")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Время конца интервью")]
        [Required(ErrorMessage = "Заполните поле!")]
        public DateTime EndTime { get; set; }

        public ICollection<Family> Families { get; set; }
        public ICollection<Data> Datas { get; set; }
    }
}