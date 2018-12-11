using System;

namespace Questionnaire.BLL.DTO
{
    public class DataDTO
    {
        public short Id { get; set; }
        public int QuestionAnswerId { get; set; }
       
        public int FormId { get; set; }
      
        public string Comment { get; set; }
        
        public QuestionAnswerDTO QuestionAnswer { get; set; }
        public FormDTO Form { get; set; }
    }
}