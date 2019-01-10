using Questionnaire.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Tests.MoqRepositories
{
    public class TestData
    {
        public static List<QuestionType> QuestionTypes = new List<QuestionType>
        {
            new QuestionType
            {
                Id = 1,
                Name = "asd"
            }
        };
    }
}
