using Microsoft.EntityFrameworkCore;
using LearningCore.DataStore.DataStoreConfigurations;
using LearningCore.DataModels;

namespace LearningCore.DataStore
{
    public class DataStoreContext : DbContext
    {

        public DataStoreContext(DbContextOptions<DataStoreContext> options) : base(options)
        {
            
        }

        public DbSet<TodoLabel> TodoCategories { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        public virtual void SaveDataChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TodoItemConfiguration());
        }
    }
}
