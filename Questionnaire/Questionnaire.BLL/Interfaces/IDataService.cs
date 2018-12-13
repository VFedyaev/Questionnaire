using Questionnaire.BLL.DTO;

namespace Questionnaire.BLL.Interfaces
{
    public interface IDataService : IService<DataDTO>
    {
        DataDTO Get(int? id);
    }
}
