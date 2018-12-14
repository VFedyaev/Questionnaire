using AutoMapper;
using Questionnaire.BLL.DTO;
using Questionnaire.WEB.Models.Account;
using Questionnaire.WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.MappingProfiles
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<QuestionTypeDTO, QuestionTypeVM>(MemberList.None).ReverseMap();
            CreateMap<QuestionDTO, QuestionVM>(MemberList.None).ReverseMap();
            CreateMap<AnswerDTO, AnswerVM>(MemberList.None).ReverseMap();
            CreateMap<QuestionAnswerDTO, QuestionAnswerVM>(MemberList.None).ReverseMap();
            CreateMap<SurveyGeographyDTO, SurveyGeographyVM>(MemberList.None).ReverseMap();
            CreateMap<HousingTypeDTO, HousingTypeVM>(MemberList.None).ReverseMap();
            CreateMap<DistrictDTO, DistrictVM>(MemberList.None).ReverseMap();
            CreateMap<InterviewerDTO, InterviewerVM>(MemberList.None).ReverseMap();
            CreateMap<FormDTO, FormVM>(MemberList.None).ReverseMap();
            CreateMap<FamilyDTO, FamilyVM>(MemberList.None).ReverseMap();
            CreateMap<DataDTO, DataVM>(MemberList.None).ReverseMap();

            CreateMap<UserDTO, UserVM>(MemberList.None).ReverseMap();
        }
    }
}