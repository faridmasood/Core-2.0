using System;
using System.Collections.Generic;
using System.Text;
using LearningCore.DataModels;
using LearningCore.DataStore.Infrastructure;


namespace LearningCore.DataStore.Repositories
{
    public interface ITodoLabelRepository : IRepository<TodoLabel>
    {
        TodoLabel GetCategoryByName(string categoryName);
    }
}
