using System;
using System.Collections.Generic;
using System.Text;
using LearningCore.DataStore.Infrastructure;
using LearningCore.DataModels;
using System.Linq;

namespace LearningCore.DataStore.Repositories
{
    public class TodoLabelRepository : RepositoryBase<TodoLabel>, ITodoLabelRepository
    {
        public TodoLabelRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public TodoLabel GetCategoryByName(string categoryName)
        {
            return DbContext.TodoCategories.Where(c => c.Name == categoryName).FirstOrDefault();
        }
    }
}
