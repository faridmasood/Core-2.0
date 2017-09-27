using System;

namespace LearningCore.Services
{
    public interface IService<T> where T : class
    {
        T GetById(Guid id);
        void Create(T entity);
        void Delete(Guid id);
        void Update(T entity);
        void Save();
    }
}
