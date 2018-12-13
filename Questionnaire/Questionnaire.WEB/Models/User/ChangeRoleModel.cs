using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.User
{
    public class ChangeRoleModel
    {
        public string UserId { get; set; }
        public string OldRole { get; set; }

        [Display(Name = "Роль")]
        public string Role { get; set; }
    }
}