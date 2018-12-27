using Questionnaire.BLL.DTO;
using System.Collections.Generic;

namespace Questionnaire.BLL.Interfaces
{
    public interface IFormService : IService<FormDTO>
    {
        IEnumerable<FormDTO> GetListOrderedByName();
        FormDTO Get(int? id);
        void RemoveData(int id);
    }
}
