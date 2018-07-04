using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WebStore.Controllers
{
    /// <summary>
    /// this controller for working with user data
    /// </summary>
    
    public class UserController : Controller
    {
        private readonly IUserData _userData;

        public UserController(IUserData userData)
        {
            _userData = userData;
        }


        /// <summary>
        /// Displaying user list
        /// </summary>
        /// <returns>UserList html page</returns>
        [Route("users")]
        public IActionResult UserList()
        {
            var users = _userData.GetAll();

            List<UserView> model = new List<UserView>(users.Count());

            foreach (var user in users)
                model.Add(
                    new UserView
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Login = user.Login,
                        Password = user.Password
                    });

            return View(model);
        }

        /// <summary>
        /// Displaying user details
        /// </summary>
        /// <returns>UserCard html page</returns>
        [Route("users/{id}")]
        public IActionResult UserCard(int id)
        {
            var selectedUser = _userData.GetById(id);

            if (selectedUser is null)
                return NotFound();

            return View(new UserView
            {
                Id = selectedUser.Id,
                Email = selectedUser.Email,
                Login = selectedUser.Login,
                Password = selectedUser.Password
            });
        }

        /// <summary>
        /// Adding or editing user
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Edit html page</returns>
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            UserView model;
            if (id.HasValue)
            {
                var user = _userData.GetById(id.Value);
                
                if (user is null)
                    return NotFound();

                model = new UserView
                {
                    Id = user.Id,
                    Email = user.Email,
                    Login = user.Login,
                    Password = user.Password
                };
            }
            else
                model = new UserView();

            return View(model);
        }

        /// <summary>
        /// Redirecting UserList view after additing or editing user
        /// </summary>
        /// <param name="model">User model</param>
        /// <returns>UserList html page</returns>
        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(UserView model)
        {
            if (model.Id > 0)
            {
                var dbItem = _userData.GetById(model.Id);

                if (dbItem is null)
                    return NotFound();

                _userData.Edit(new User
                {
                    Id = model.Id,
                    Email = model.Email,
                    Login = model.Login,
                    Password = model.Password
                });
            }
            else
                _userData.AddNew(new User
                {
                    Id = model.Id,
                    Email = model.Email,
                    Login = model.Login,
                    Password = model.Password
                });

            return RedirectToAction(nameof(UserList));
        }

        /// <summary>
        /// Deleting an user
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>UserList html page</returns>
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _userData.Delete(id);
            return RedirectToAction(nameof(UserList));
        }
    }
}