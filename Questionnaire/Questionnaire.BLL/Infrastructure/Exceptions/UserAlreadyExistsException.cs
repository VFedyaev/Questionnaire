using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Infrastructure.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        static string message = "User already exists.";

        public UserAlreadyExistsException() : base(message) { }
    }
}
