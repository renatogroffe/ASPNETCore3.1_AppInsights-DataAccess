using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using APIDataAccess.EntityImpl;
using APIDataAccess.NHibernateImpl;

namespace APIDataAccess
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Ativando o uso do Entity Framework Core
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<DadosGeograficosContext>(
                    options => options.UseSqlServer(
                        Configuration.GetConnectionString("DadosGeograficos")));

            // Ativando o uso do FluentNHibernate
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                    Configuration.GetConnectionString("DadosGeograficos")))
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<RegiaoMap>())
                .BuildSessionFactory();        
            
            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());

            // Ativando o Application Insights
            services.AddApplicationInsightsTelemetry(Configuration);
        }

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
    }
}