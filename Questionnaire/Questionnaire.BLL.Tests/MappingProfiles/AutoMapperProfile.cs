using AutoMapper;
using Questionnaire.BLL.DTO;
using Questionnaire.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Tests.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<QuestionType, QuestionTypeDTO>(MemberList.None).ReverseMap();
        }
    }
}
