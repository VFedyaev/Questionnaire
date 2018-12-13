using Questionnaire.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace Questionnaire.DAL.Interfaces
{
    public interface IAccountWorker : IDisposable
    {
        //ApplicationUserManager UserManager { get; }
        //ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
        void Save();
    }
}
