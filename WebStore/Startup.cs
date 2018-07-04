using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStore.DAL.Context;
using WebStore.Infrastructure.Implementations;
using WebStore.Infrastructure.Interfaces;
using WebStore.Repositories.Implementations;
using WebStore.Repositories.Interfaces;

namespace WebStore
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();            

            services.AddSingleton<IEmployeeData, EmployeeDataService>();
            services.AddSingleton<IProductData, ProductDataService>();

            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IProductDataRepository, ProductDataRepository>();

            services.AddDbContext<WebStoreContext>(options => options.UseSqlServer("Data Source=DESKTOP-G14CHN2\\SQLEXPRESS;Initial Catalog=WebStoreDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=index}/{id?}");
            });
        }
    }
}
