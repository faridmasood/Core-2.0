using Microsoft.EntityFrameworkCore;
using LearningCore.DataStore;

namespace LearningCore.DataStore.Infrastructure
{
    public class DbFactory : Disposible, IDbFactory
    {
        private DataStoreContext context;
        private readonly IDbSettings dbSettings;

        public DbFactory(IDbSettings dbSettings)
        {
            this.dbSettings = dbSettings;
        }

        public DataStoreContext Init()
        {
            return context ?? (context = GetNewContextInstance());
        }

        private DataStoreContext GetNewContextInstance()
        {
            // Build the context options with the corret settings!!
            var ContextOptions = new DbContextOptionsBuilder<DataStoreContext>();
            ContextOptions.UseSqlServer(dbSettings.ConnectionString);

            // Create the context!
            var rtrContext = new DataStoreContext(ContextOptions.Options);
            return rtrContext;
        }

        protected override void DisposeContext()
        {
            if (context != null)
                context.Dispose();
        }
    }
}
