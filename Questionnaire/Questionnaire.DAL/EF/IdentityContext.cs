using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Questionnaire.DAL.Entities;

namespace Questionnaire.DAL.EF
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<IdentityContext>(null);
        }
    }
}
