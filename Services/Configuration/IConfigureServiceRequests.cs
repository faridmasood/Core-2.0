using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using LearningCore.DataStore.Infrastructure;
using LearningCore.DataStore.Repositories;
using LearningCore.DataStore;
using LearningCore.DataStore.Seed;

namespace LearningCore.Services.Configuration
{
    public interface IConfigurationSettings
    {
        string DatabaseConnectionString { get; set; }
    }

    public interface IConfigureServiceRequests
    {
        void ConfigureServiceRequests(ref IServiceCollection services);
    }


    public class ServiceConfigurationSettings : IConfigurationSettings
    {
        public string DatabaseConnectionString { get; set; }
    }

    public class ServiceConfiguration : IConfigureServiceRequests
    {
        private IConfigurationSettings _configurations;

        public ServiceConfiguration(IConfigurationSettings configurations)
        {
            _configurations = configurations;
        }

        public void ConfigureServiceRequests(ref IServiceCollection services)
        {
            // DBsettings
            services.AddSingleton<IDbSettings>(new DbSettings(_configurations.DatabaseConnectionString));

            // DBFactory - UnitOfWork (These need to be singleton!!)
            services.AddSingleton<IDbFactory, DbFactory>();
            services.AddSingleton<LearningCore.DataStore.Infrastructure.IUnitOfWork, LearningCore.DataStore.Infrastructure.UnitOfWork>();

            // register the data seeder service
            services.AddTransient<DbSeedData>();


            // Repositories
            //services.AddTransient(typeof(ToDoDataStore.Infrastructure.IRepository<>), AppDomain.CurrentDomain.GetAssemblies());
            //services.AddTransient(typeof(LearningCore.DataStore.Infrastructure.IRepository<>), AppDomain.CurrentDomain.GetAssemblies().GetType());
            services.AddTransient<ITodoLabelRepository, TodoLabelRepository>();
            services.AddTransient<ITodoItemRepository, TodoItemRepository>();

            // Services
            services.AddTransient<ITodoLabelService, TodoLabelService>();
            services.AddTransient<ITodoItemService, TodoItemService>();
        }
    }

}
