using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Entities
{
    public class QuestionAnswerVM
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }

        public QuestionDTO Question { get; set; }
        public AnswerDTO Answer { get; set; }

        public ICollection<DataDTO> Datas { get; set; }
    }
}