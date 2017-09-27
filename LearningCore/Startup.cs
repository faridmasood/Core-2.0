using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LearningCore.DataStore.Seed;
using LearningCore.Services.Configuration;

namespace LearningCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure the database context with the connection string!!
            //services.AddDbContext<DataStoreContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("TodoDatabase")));

            ConfigureDataAndServices(ref services);


            // Configure auto mapper
            services.AddTransient<AutoMapperConfiguration>();

            //// register the data seeder service
            //services.AddTransient<DbSeedData>();


            services.AddMvc();

            /*
             For token generation and authentication of requests.
             https://identityserver4.readthedocs.io/en/release/quickstarts/0_overview.html
             https://stormpath.com/blog/token-authentication-asp-net-core
             */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AutoMapperConfiguration autoMapper, DbSeedData dataSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            dataSeeder.SeedData();

            autoMapper.ConfigureObjectMappings();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureDataAndServices(ref IServiceCollection services)
        {
            IConfigurationSettings ConfigurationSettings = new ServiceConfigurationSettings();
            ConfigurationSettings.DatabaseConnectionString = Configuration.GetConnectionString("TodoDatabase");

            IConfigureServiceRequests ConfigureServiceRequests = new ServiceConfiguration(ConfigurationSettings);
            ConfigureServiceRequests.ConfigureServiceRequests(ref services);

            //// Services
            //services.AddTransient<ITodoCategoryService, TodoCategoryService>();
            //services.AddTransient<ITodoItemService, TodoItemService>();
        }
    }
}
