using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using GenericRepository.Entities;
using GenericRepository.Interface;
using System.Linq.Expressions;
using System.Linq;

namespace GenericRepository.Base
{
    public abstract class BaseRepository<T> : IRepository<T> where T : Entity, IAggregateRoot, new()
    {
        IDatabaseContext _dataContext;
        private DbContext _context;
        protected DbSet<T> dbSet;

        public BaseRepository(IDatabaseContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException("context");
            _context = _dataContext.Context;
            dbSet = _context.Set<T>();
        }

        public string Insert(T entity)
        {
            try
            {
                dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Added;
                _context.SaveChanges();
                return entity.Id;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int Update(T entity)
        {

            try
            {
                dbSet.AddOrUpdate(entity);
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int Delete(T entity)
        {
            dbSet.Attach(entity);
            var result = dbSet.Remove(entity);
            return _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query;
        }

        public virtual IEnumerable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }
    }
}
