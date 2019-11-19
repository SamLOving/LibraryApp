using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using HotChocolate.Execution.Configuration;
using LibraryApp.Queries;
using LibraryApp.Repositories;
using LibraryApp.Resolvers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LibraryApp
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
            services.AddSingleton<NLog.ILogger>(_ => NLog.LogManager.GetLogger("LibraryApp"));
            services.AddSingleton<BooksRepository>(serviceProvider => {
                var repository = new BooksRepository();
                repository.PopulateBooks();
                return repository;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            ConfigureGraphQL(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
            app.UseGraphQL("/graphql");
        }

        private void ConfigureGraphQL(IServiceCollection services)
        {
            services.AddTransient<BooksResolver>();

            services.AddDataLoaderRegistry();

            var excecutionOptions = new QueryExecutionOptions
            {
                ExecutionTimeout = TimeSpan.FromMinutes(5)
            };

            var schema = Schema.Create(schemaConfiguration =>
            {
                schemaConfiguration.RegisterQueryType<RootQueryType>();
            });

            services.AddGraphQL(schema, builder => builder
                .UseDefaultPipeline(excecutionOptions));
        }
    }
}
