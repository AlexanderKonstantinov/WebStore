using System.Collections.Generic;
using WebStore.Domain.Entities;

namespace WebStore.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface describe connecting UserController with Database
    /// </summary>
    public interface IUserData
    {
        /// <summary>
        /// Get user list
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAll();

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns>required user or null if employee with such Id does not exist</returns>
        User GetById(int id);

        /// <summary>
        /// Adding new user
        /// </summary>
        /// <param name="user">model of new user</param>
        void AddNew(User user);

        /// <summary>
        /// Deleting user by id
        /// </summary>
        /// <param name="id">identifier</param>
        void Delete(int id);

        /// <summary>
        /// Editing user
        /// </summary>
        /// <param name="user">correct model of user</param>
        void Edit(User user);
    }
}
