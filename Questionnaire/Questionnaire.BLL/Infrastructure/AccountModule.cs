using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //Bind<IAccountWorker>().To<AccountWorker>().WithConstructorArgument(connectionString);
        }
    }
}
