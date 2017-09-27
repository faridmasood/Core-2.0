using System;
using System.Collections.Generic;
using System.Text;
using LearningCore.DataStore.Infrastructure;
using LearningCore.DataModels;
using System.Linq;

namespace LearningCore.DataStore.Repositories
{
    public class TodoItemRepository : RepositoryBase<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<TodoItem> GetByCategory(Guid id)
        {
            var todoItems = base.GetMany(td => td.LabelId == id);
            return todoItems;
        }
    }
}
