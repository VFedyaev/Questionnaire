using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;

namespace Questionnaire.BLL.Interfaces
{
    public interface IInterviewerService : IService<InterviewerDTO>
    {
        IEnumerable<InterviewerDTO> GetListOrderedByName();
        InterviewerDTO Get(int? id);
    }
}
