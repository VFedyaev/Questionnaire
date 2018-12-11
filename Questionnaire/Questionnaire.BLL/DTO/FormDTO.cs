using System;

namespace Questionnaire.BLL.DTO
{
    public class FormDTO
    {
        public int Id { get; set; }
        public int SurveyGeographyId { get; set; }
        public int HousingTypeId { get; set; }
        public int DistrictId { get; set; }    
        public int InterviewerId { get; set; }       
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime InterviewDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public SurveyGeographyDTO SurveyGeography { get; set; }
        public HousingTypeDTO HousingType { get; set; }
        public DistrictDTO District { get; set; }
        public InterviewerDTO Interviewer { get; set; }
    }
}