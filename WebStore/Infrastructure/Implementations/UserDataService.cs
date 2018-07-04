using System.Collections.Generic;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    /// <summary>
    /// Layer between UserController and Database
    /// Responsible for getting, updating for controller and view data transfer to the database 
    /// </summary>
    public class UserDataService : IUserData
    {
        private readonly WebStoreContext _context;

        public UserDataService(WebStoreContext context)
        {
            _context = context;
        }

        #region Логика временная

        public IEnumerable<User> GetAll() => _context.Users;

        public User GetById(int id) => _context.Users.FirstOrDefault(e => e.Id == id);

        public void AddNew(User newUser)
        {
            _context.Users.Add(newUser);
        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(e => e.Id == id);

            if (user is null) return;

            _context.Users.Remove(user);
        }

        public void Edit(User editedUser)
        {
            var user = _context.Users.FirstOrDefault(e => e.Id == editedUser.Id);

            if (user is null) return;

            user.Id = editedUser.Id;
            user.Login = editedUser.Login;
            user.Email = editedUser.Email;
            user.Password = editedUser.Password;
        }         

        #endregion
    }
}
