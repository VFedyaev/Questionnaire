using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;

namespace Questionnaire.BLL.Interfaces
{
    public interface IAnswerService : IService<AnswerDTO>
    {
        IEnumerable<AnswerDTO> GetListOrderedByName();
        AnswerDTO Get(int? id);
    }
}
