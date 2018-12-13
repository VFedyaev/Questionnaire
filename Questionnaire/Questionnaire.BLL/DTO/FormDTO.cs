using System;

namespace Questionnaire.BLL.DTO
{
    public class FormDTO
    {
        public int Id { get; set; }
        public short SurveyGeographyId { get; set; }
        public short HousingTypeId { get; set; }
        public short DistrictId { get; set; }    
        public short InterviewerId { get; set; }       
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime InterviewDate { get; set; }
        public DateTime StartTime { get; set; }
        public Nullable<DateTime> EndTime { get; set; }

        public SurveyGeographyDTO SurveyGeography { get; set; }
        public HousingTypeDTO HousingType { get; set; }
        public DistrictDTO District { get; set; }
        public InterviewerDTO Interviewer { get; set; }
    }
}