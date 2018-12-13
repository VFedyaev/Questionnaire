using Questionnaire.BLL.DTO;

namespace Questionnaire.BLL.Interfaces
{
    public interface IQuestionAnswerService : IService<QuestionAnswerDTO>
    {
        void Create(int questionId, int answerId);
        void UpdateQuestionRelations(int? questionId, string[] answerIds);
        void DeleteRelationsByQuestionId(int id);
    }
}
