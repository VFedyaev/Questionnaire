using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Infrastructure.Exceptions
{
    public class UniqueConstraintException : Exception
    {
        static string message = "Record is not unique";

        public UniqueConstraintException() : base(message) { }
    }
}
