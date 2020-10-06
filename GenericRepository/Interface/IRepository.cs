using GenericRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GenericRepository.Interface
{
    public interface IRepository<T> where T : Entity, IAggregateRoot
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        string Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        IEnumerable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    }
}
