using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearningCore.Services.ServiceModels;

namespace LearningCore.Services
{
    public interface ITodoItemService : IService<TodoServiceModel>
    {
        Task<IEnumerable<TodoServiceModel>> GetAllTodo();
        IEnumerable<TodoServiceModel> GetByCategory(Guid id);
    }
}
