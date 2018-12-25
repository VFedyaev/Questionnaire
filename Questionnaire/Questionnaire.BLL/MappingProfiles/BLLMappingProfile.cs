using AutoMapper;
using Questionnaire.BLL.DTO;
using Questionnaire.DAL.Entities;

namespace Questionnaire.BLL.MappingProfiles
{
    public class BLLMappingProfile : Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<QuestionType, QuestionTypeDTO>(MemberList.None).ReverseMap();
            CreateMap<Question, QuestionDTO>(MemberList.None).ReverseMap();
            CreateMap<Answer, AnswerDTO>(MemberList.None).ReverseMap();
            CreateMap<QuestionAnswer, QuestionAnswerDTO>(MemberList.None).ReverseMap();
            CreateMap<SurveyGeography, SurveyGeographyDTO>(MemberList.None).ReverseMap();
            CreateMap<HousingType, HousingTypeDTO>(MemberList.None).ReverseMap();
            CreateMap<District, DistrictDTO>(MemberList.None).ReverseMap();
            CreateMap<Interviewer, InterviewerDTO>(MemberList.None).ReverseMap();
            CreateMap<Form, FormDTO>(MemberList.None).ReverseMap();
            CreateMap<Family, FamilyDTO>(MemberList.None).ReverseMap();
            CreateMap<Data, DataDTO>(MemberList.None).ReverseMap();

            CreateMap<ApplicationRole, RoleDTO>(MemberList.None).ReverseMap();
            CreateMap<ApplicationUser, UserDTO>(MemberList.None).ReverseMap();
        }
    }
}
