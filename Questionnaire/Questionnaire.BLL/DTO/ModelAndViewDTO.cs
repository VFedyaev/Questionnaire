using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.DTO
{
    public class ModelAndViewDTO
    {
        public IEnumerable<object> Model { get; set; }
        public string View { get; set; }
    }
}
