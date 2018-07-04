using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebStore.Domain.Entities;


namespace WebStore.DAL.Context
{
    public class WebStoreContext : DbContext
    {
        public WebStoreContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Brand> Brands { get; set; }

        private List<User> _users;
        public List<User> Users
            => _users ?? (_users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "aaa@gmail.com",
                    Login = "aaa",
                    Password = "aaa"
                },
                new User
                {
                    Id = 2,
                    Email = "bbb@gmail.com",
                    Login = "bbb",
                    Password = "bbb"
                },
                new User
                {
                    Id = 3,
                    Email = "ccc@gmail.com",
                    Login = "ccc",
                    Password = "ccc"
                }
            });
    }
}
