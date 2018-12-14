using Ninject.Modules;
using Questionnaire.DAL.Interfaces;
using Questionnaire.DAL.Repositories;

namespace Questionnaire.BLL.Infrastructure
{
    public class AccountModule : NinjectModule
    {
        private string connectionString;

        public AccountModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IAccountWorker>().To<AccountWorker>().WithConstructorArgument(connectionString);
        }
    }
}
