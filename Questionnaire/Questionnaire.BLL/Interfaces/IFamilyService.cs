using Questionnaire.BLL.DTO;

namespace Questionnaire.BLL.Interfaces
{
    public interface IFamilyService : IService<FamilyDTO>
    {
        FamilyDTO Get(int? id);
    }
}
