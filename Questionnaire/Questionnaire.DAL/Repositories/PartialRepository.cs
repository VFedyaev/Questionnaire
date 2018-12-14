using Questionnaire.DAL.EF;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DAL.Repositories
{
    class PartialRepository<T> : IPartialRepository<T> where T : class
    {
        private QuestionnaireContext questionnaireContext;
        private IdentityContext AccountContext;
        private DbSet<T> DbSet;

        public PartialRepository(QuestionnaireContext context)
        {
            questionnaireContext = context;
            DbSet = context.Set<T>();
        }

        public PartialRepository(IdentityContext context)
        {
            AccountContext = context;
            DbSet = context.Set<T>();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return GetAll().Where(predicate);
        }

        public T Get(int? id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet;
        }

    }
}
