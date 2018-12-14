using Microsoft.AspNet.Identity;
using Questionnaire.DAL.Entities;

namespace Questionnaire.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store) { }
    }
}
