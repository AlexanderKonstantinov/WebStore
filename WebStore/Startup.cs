using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStore.Clients;
using WebStore.Clients.Services.Employees;
using WebStore.Clients.Services.Orders;
using WebStore.Clients.Services.Products;
using WebStore.Clients.Services.Users;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Clients;
using WebStore.Interfaces.Services;
using WebStore.Services;
using WebStore.Services.Sql;
using WebStore.Services.CustomIdentity;

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
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ICartService, CookieCartService>();

            services.AddDbContext<WebStoreContext>(options => options.UseSqlServer(
                _configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IValuesService, ValuesClient>();
            services.AddTransient<IEmployeesData, EmployeesClient>();
            services.AddTransient<IProductData, ProductsClient>();
            services.AddTransient<IOrdersData, OrdersClient>();
            services.AddTransient<IUsersClient, UsersClient>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WebStoreContext>()
                .AddDefaultTokenProviders();

            //services.AddTransient<IUserStore<User>, CustomUserStore>();
            //services.AddTransient<IUserRoleStore<User>, CustomUserStore>();
            //services.AddTransient<IUserClaimStore<User>, CustomUserStore>();
            //services.AddTransient<IUserPasswordStore<User>, CustomUserStore>();
            //services.AddTransient<IUserTwoFactorStore<User>, CustomUserStore>();
            //services.AddTransient<IUserEmailStore<User>, CustomUserStore>();
            //services.AddTransient<IUserPhoneNumberStore<User>,CustomUserStore>();
            //services.AddTransient<IUserLoginStore<User>, CustomUserStore>();
            //services.AddTransient<IUserLockoutStore<User>, CustomUserStore>();
            //services.AddTransient<IRoleStore<IdentityRole>, RolesClient>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout"; 
                options.AccessDeniedPath = "/Account/AccessDenied"; 
                options.SlidingExpiration = true;
            });

            services.AddAutoMapper();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
