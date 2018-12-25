using Microsoft.AspNet.Identity.EntityFramework;

namespace Questionnaire.DAL.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }
        public ApplicationRole(string name) { Name = name; }

        public string Description { get; set; }
    }
}
