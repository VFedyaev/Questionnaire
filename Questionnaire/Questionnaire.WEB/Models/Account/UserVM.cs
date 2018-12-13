using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Account
{
    public class UserVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}