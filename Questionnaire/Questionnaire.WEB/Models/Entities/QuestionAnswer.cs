using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Entities
{
    public class QuestionAnswer
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }

        public ICollection<Data> Datas { get; set; }
    }
}