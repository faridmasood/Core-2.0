using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCore.DataStore.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
