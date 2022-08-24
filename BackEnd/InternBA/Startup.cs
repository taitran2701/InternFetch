using InternBA;
using InternBA.Controllers;
using InternBA.Infrastructure.Data;
using InternBA.Interfaces;
using InternBA.Models;
/*using InternBA.Repository;
*/using Microsoft.EntityFrameworkCore;

namespace WebApi
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
            services.AddControllers();
            services.AddDbContext<InternBADBContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("mydata"),
                b => b.MigrationsAssembly(typeof(InternBADBContext).Assembly.FullName)));

            /*#region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            #endregion*/
/*            IServiceCollection serviceCollection = services.AddTransient<UnitOfWork, UnitOfWork>();
*/        }

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
    }
}