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

        public User GetById(int id) => null;

        public void AddNew(User newUser)
        {
            
        }

        public void Delete(int id)
        {
            
        }

        public void Edit(User editedUser)
        {
           
        }         

        #endregion
    }
}
