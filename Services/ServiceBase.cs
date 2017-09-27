using LearningCore.DataStore.Infrastructure;

namespace LearningCore.Services
{
    public abstract class ServiceBase
    {
        private readonly IUnitOfWork unitOfWork;
        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected virtual void SaveContext()
        {
            unitOfWork.Commit();
        }

        //T GetById(Guid id) { }
        //void Delete(Guid id) { }
        //void Update(T entity) { }
        //void Create(T entity) { }
        //void Save() { }
    }
}
