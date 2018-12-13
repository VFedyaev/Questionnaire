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
    class BaseRepository<T> : IRepository<T> where T : class
    {
        private QuestionnaireContext Context;
        private DbSet<T> DbSet;

        public BaseRepository(QuestionnaireContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet;
        }

        public T Get(int? id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> Find(Func<T,Boolean> predicate)
        {
            return GetAll().Where(predicate);
        }

        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            var entityEntry = Context.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
                DbSet.Attach(entity);
            entityEntry.State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T entitiy = DbSet.Find(id);
            if (entitiy != null)
                DbSet.Remove(entitiy);
        }
    }
}
