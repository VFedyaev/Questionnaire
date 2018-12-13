using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Account
{
    public class ChangeEmailModel
    {
        [Required]
        [Display(Name = "Почта")]
        public string Email { get; set; }
    }
}