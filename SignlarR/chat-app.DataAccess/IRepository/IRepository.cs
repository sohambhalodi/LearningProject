﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.DataAccess.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T,bool>> filter, string? includeProperties = null); 
        IEnumerable<T> GetAll(string? includeProperties = null);

        T Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Remove(T entity);
		//void Update(T entity);
		void RemoveRange(IEnumerable<T> entities);
    }
}
