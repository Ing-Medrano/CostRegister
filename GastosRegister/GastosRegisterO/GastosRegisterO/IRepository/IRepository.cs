using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GastosRegisterO.IRepository
{
    public interface IRepository<T> where T : class
    {

        T Get(int Id);
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string IncludeProperties = null

            );
        T GetFirstOrDefoult(
                Expression<Func<T, bool>> filter = null,
            string IncludeProperties = null
            );
        void Add(T entity);
        void Remove(T entity);
        void Remove(int id);
    }
}
