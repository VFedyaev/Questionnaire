using Questionnaire.BLL.DTO;
using System.Collections.Generic;

namespace Questionnaire.BLL.Interfaces
{
    public interface IFamilyService : IService<FamilyDTO>
    {
        IEnumerable<FamilyDTO> GetListOrderedByName();
        FamilyDTO Get(int? id);
    }
}
