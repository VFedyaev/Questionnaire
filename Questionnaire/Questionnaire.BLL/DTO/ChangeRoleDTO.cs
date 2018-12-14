using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.DTO
{
    public class ChangeRoleDTO
    {
        public string UserId { get; set; }
        public string OldRole { get; set; }
        public string Role { get; set; }
    }
}
