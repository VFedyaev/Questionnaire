using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;

namespace Questionnaire.BLL.Interfaces
{
    public interface IDistrictService : IService<DistrictDTO>
    {
        IEnumerable<DistrictDTO> GetListOrderedByName();
        DistrictDTO Get(int? id);
    }
}
