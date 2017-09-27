using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCore.DataStore.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private DataStoreContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public DataStoreContext DbContext
        {
            get
            {
                return dbContext ?? (dbContext = dbFactory.Init());
            }
        }

        public void Commit()
        {
            DbContext.SaveDataChanges();
        }
    }
}
