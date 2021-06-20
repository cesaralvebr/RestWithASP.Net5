using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWithASP.Net5.Context;
using RestWithASP.Net5.Business.Implementations;
using RestWithASP.Net5.Business.InterfacesBusiness;
using System;
using Serilog;
using System.Collections.Generic;
using RestWithASP.Net5.Repository.Generic;

namespace RestWithASP.Net5
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));
            //, new MySqlServerVersion(new Version(8, 0, 11))
            if (Environment.IsDevelopment())
            {
                MigrateDatabse(connection);
            }

            //Versioning api
            services.AddApiVersioning();
            //Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();           
            services.AddScoped<IBooksBusiness, BooksBusinessImplementation>();     
            services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        } 
        private void MigrateDatabse(string connection)
        {
            try
            {
                var envolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var envolve = new Evolve.Evolve(envolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "Db/Migrations", "Db/Dataset" },
                    IsEraseDisabled = true
                };
                envolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw;
            }
        }
    }
}
