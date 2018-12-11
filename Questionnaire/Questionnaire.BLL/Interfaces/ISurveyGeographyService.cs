using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;

namespace Questionnaire.BLL.Interfaces
{
    public interface ISurveyGeographyService : IService<SurveyGeographyDTO>
    {
        IEnumerable<SurveyGeographyDTO> GetListOrderedByName();
        SurveyGeographyDTO Get(int? id);
    }
}
