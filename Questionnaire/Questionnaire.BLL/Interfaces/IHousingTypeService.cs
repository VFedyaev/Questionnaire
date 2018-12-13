using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;

namespace Questionnaire.BLL.Interfaces
{
    public interface IHousingTypeService : IService<HousingTypeDTO>
    {
        IEnumerable<HousingTypeDTO> GetListOrderedByName();
        HousingTypeDTO Get(int? id);
    }
}
