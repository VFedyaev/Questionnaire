using System;

namespace Questionnaire.BLL.DTO
{
    public class QuestionAnswerDTO
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }      
        public int AnswerId { get; set; }

        public QuestionDTO Question { get; set; }
        public AnswerDTO Answer { get; set; }
    }
}