using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Entities
{
    public class FormVM
    {
        public int Id { get; set; }

        [Display(Name = "Номер анкеты")]
        [Required(ErrorMessage = "Необходимо заполнить поле номер формы!")]
        public int NumberForm { get; set; }

        [Display(Name = "Место обследования")]
        [Required(ErrorMessage = "Необходимо выбрать место проведения опроса!")]
        public short SurveyGeographyId { get; set; }

        [Display(Name = "Тип жилья")]
        [Required(ErrorMessage = "Необходимо выбрать тип жилья!")]
        public short HousingTypeId { get; set; }

        [Display(Name = "Район")]
        [Required(ErrorMessage = "Необходимо выбрать район!")]
        public short DistrictId { get; set; }

        [Display(Name = "ФИО интервьюера")]
        [Required(ErrorMessage = "Необходимо выбрать интерьюера!")]
        public short InterviewerId { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(300, ErrorMessage = "Длина строки не должна превышать 300 символов")]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Address { get; set; }

        [Display(Name = "Контактный телефон")]
        [StringLength(30, ErrorMessage = "Длина строки не должна превышать 30 символов")]
        public string Phone { get; set; }
   
        [Display(Name = "Дата проведения интервью")]
        [Required(ErrorMessage = "Заполните поле!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InterviewDate { get; set; }

        [Display(Name = "Время начала интервью")]
        [Required(ErrorMessage = "Заполните поле!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Display(Name = "Время конца интервью")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> EndTime { get; set; }

        public SurveyGeographyDTO SurveyGeography { get; set; }
        public HousingTypeDTO HousingType { get; set; }
        public DistrictDTO District { get; set; }
        public InterviewerDTO Interviewer { get; set; }

        public ICollection<FamilyDTO> Families { get; set; }
        public ICollection<DataDTO> Datas { get; set; }
    }
}