using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.DTO
{
    public class FormDataDTO
    {
        public int QuestionAnswerId { get; set; }
        public string QuestionTypeName { get; set; }
        public string QuestionName { get; set; }
        public string AnswerName { get; set; }
    }
}
