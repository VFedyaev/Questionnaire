using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Infrastructure.Exceptions
{
    public class OldPasswordIsWrongException : Exception
    {
        static string message = "Old password is incorrect.";

        public OldPasswordIsWrongException() : base(message) { }
    }
}
