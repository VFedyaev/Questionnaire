using Questionnaire.BLL.DTO;

namespace Questionnaire.BLL.Interfaces
{
    public interface ISearchService
    {
        ModelAndViewDTO GetFilteredModelAndView(string input, string type);
    }
}
