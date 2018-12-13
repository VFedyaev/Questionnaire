using Questionnaire.BLL.DTO;

namespace Questionnaire.BLL.Interfaces
{
    public interface IFormService : IService<FormDTO>
    {
        FormDTO Get(int? id);
    }
}
