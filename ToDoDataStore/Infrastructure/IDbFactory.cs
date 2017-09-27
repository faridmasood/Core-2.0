using System;

namespace LearningCore.DataStore.Infrastructure
{
    public interface IDbFactory: IDisposable
    {
        DataStoreContext Init();
    }
}
