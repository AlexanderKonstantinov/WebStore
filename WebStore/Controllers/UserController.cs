using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WebStore.Controllers
{
    /// <summary>
    /// this controller for working with user data
    /// </summary>

    [Authorize]
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

            List<UserViewModel> model = new List<UserViewModel>(users.Count());



            return View(model);
        }

        /// <summary>
        /// Displaying user details
        /// </summary>
        /// <returns>UserCard html page</returns>
        [Route("users/{id}")]
        public IActionResult UserCard(int id)
        {
            return null;
        }

        /// <summary>
        /// Adding or editing user
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Edit html page</returns>
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            UserViewModel model = null;
           

            return View(model);
        }

        /// <summary>
        /// Redirecting UserList view after additing or editing user
        /// </summary>
        /// <param name="model">User model</param>
        /// <returns>UserList html page</returns>
        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(UserViewModel model)
        {
            

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