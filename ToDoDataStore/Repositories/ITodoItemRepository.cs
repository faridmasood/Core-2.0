using System;
using System.Collections.Generic;
using System.Text;
using LearningCore.DataModels;
using LearningCore.DataStore.Infrastructure;


namespace LearningCore.DataStore.Repositories
{
    public interface ITodoItemRepository : IRepository<TodoItem>
    {
        IEnumerable<TodoItem> GetByCategory(Guid id);
    }
}
