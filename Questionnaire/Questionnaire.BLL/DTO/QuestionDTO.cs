using System;

namespace Questionnaire.BLL.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public short QuestionTypeId { get; set; }
        public string Name { get; set; }

        public QuestionTypeDTO QuestionType { get; set; }
    }
}