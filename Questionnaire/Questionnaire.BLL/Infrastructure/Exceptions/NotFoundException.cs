using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        static string message = "Item with given id was not found.";

        public NotFoundException() : base(message) { }
    }
}
