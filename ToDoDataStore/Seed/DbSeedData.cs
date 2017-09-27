using System;
using System.Collections.Generic;
using System.Text;
using LearningCore.DataModels;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using LearningCore.DataStore.Infrastructure;

namespace LearningCore.DataStore.Seed
{
    public class DbSeedData 
    {
        private DataStoreContext context;

        public DbSeedData(IDbFactory dbFactory)
        {
            this.context = dbFactory.Init();
        }

        public void SeedData()
        {
            context.Database.EnsureCreated();

            if (context.TodoCategories.Any())
                return;

            context.TodoCategories.Add(new TodoLabel() { Name = "Todo Category" });
            context.SaveDataChanges();

            context.TodoItems.Add(new TodoItem() { Text = "Todo Item", LabelId = context.TodoCategories.FirstOrDefault().Id });
            context.SaveDataChanges();
        }
    }
}
