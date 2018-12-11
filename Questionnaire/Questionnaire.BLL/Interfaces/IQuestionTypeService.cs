using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;

namespace Questionnaire.BLL.Interfaces
{
    public interface IQuestionTypeService : IService<QuestionTypeDTO>
    {
        IEnumerable<QuestionTypeDTO> GetListOrderedByName();
        QuestionTypeDTO Get(int? id);
    }
}
