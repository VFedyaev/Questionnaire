﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DAL.Interfaces
{
    public interface IPartialRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int? id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
    }
}
