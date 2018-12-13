using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;

namespace Questionnaire.BLL.Interfaces
{
    public interface IQuestionService : IService<QuestionDTO>
    {
        IEnumerable<QuestionDTO> GetListOrderedByName();
        QuestionDTO Get(int? id);
    }
}
