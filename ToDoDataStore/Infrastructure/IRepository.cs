using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LearningCore.DataStore.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);
        // Marks an entity as modified
        void Update(T entity);
        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        // Get an entity by int id
        Task<T> GetByIdAsync(Guid id);
        T GetById(Guid id);
        // Get an entity using delegate
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where);
        // Gets all entities of type T
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();
        // Gets entities using delegate
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
