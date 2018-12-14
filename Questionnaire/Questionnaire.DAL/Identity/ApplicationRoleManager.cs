using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Questionnaire.DAL.Entities;

namespace Questionnaire.DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store) : base(store) { }
    }
}
