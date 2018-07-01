using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Implementations;
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
