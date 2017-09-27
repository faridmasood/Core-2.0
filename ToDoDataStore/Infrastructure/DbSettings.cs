using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCore.DataStore.Infrastructure
{
    public class DbSettings : IDbSettings
    {
        private string _connectionString = "";

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        public DbSettings(string connectionString)
        {
            this._connectionString = connectionString;
        }
    }
}
