using GastosRegisterO.Data;
using GastosRegisterO.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GastosRegisterO.CRepository
{
    public class CRepository<T> : IRepository<T> where T : class
    {
protected readonly ApplicationDbContext _context;
        internal DbSet<T> _db;
        public CRepository(ApplicationDbContext context)
        {
            _context = context;
            this._db = context.Set<T>();
        }

        public void Add(T entity)
        {
            _db.Add(entity);
        }

        public T Get(int Id)
        {
            var db = _db.Find(Id);
            return db;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string IncludeProperties = null)
        {
            IQueryable<T> query = _db;
            if (filter != null)
            {
                query = query.Where(filter);
              

            }
            if (IncludeProperties != null)
            {

                foreach(var includeProperties in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)){

                    query.Include(includeProperties);

                }
               
            }

            if(orderby!=null)
            {

              orderby(query).ToList();

            }
            return query.ToList();
        }

        public T GetFirstOrDefoult(Expression<Func<T, bool>> filter = null, string IncludeProperties = null)
        {

            IQueryable<T> query = _db;
            if (filter != null)
            {
                query = query.Where(filter);
              

            }
            if (IncludeProperties != null)
            {

                foreach (var includeProperties in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {

                    query.Include(includeProperties);

                }
               
            }

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _db.Remove(entity);
        }

        public void Remove(int id)
        {
            T db= _db.Find(id);
            _db.Remove(db);
            
        }
    }
}
