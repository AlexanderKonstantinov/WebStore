using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models.Account;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var userName = userModel.EmailOrUserName;

                // Сначала проверяем является ли введенная пользователем строка электронным адресом
                if (userName.IndexOf('@') > -1)
                {
                    var user =  await _userManager.FindByEmailAsync(userModel.EmailOrUserName);
                    if (user is null)
                    {
                        ModelState.AddModelError(String.Empty, "Неверные параметры входа");
                        return View(userModel);
                    }
                    // Если является, то перезаписываем userName на значение, полученное из БД
                    else
                        userName = user.UserName;
                }

                var loginResult = await _signInManager.PasswordSignInAsync(userName,
                    userModel.Password,
                    userModel.RememberMe,
                    lockoutOnFailure: false);

                if (loginResult.Succeeded)
                {
                    if (Url.IsLocalUrl(userModel.ReturnUrl))
                        return Redirect(userModel.ReturnUrl);

                    return RedirectToAction(controllerName: "Home", actionName: "Index");
                }
            }

            ModelState.AddModelError(String.Empty, "Вход невозможен");

            return View(userModel);
        }

        [HttpGet]
        public IActionResult Register() => View(new RegisterUserViewModel());

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = userModel.Email,
                    UserName = userModel.UserName
                };

                if (user.UserName is null || user.UserName == String.Empty)
                    user.UserName = new string(user.Email.TakeWhile(s => s != '@').ToArray());

                var createResult = await _userManager.CreateAsync(user, userModel.Password);

                if (createResult.Succeeded)
                {
                    // Что может быть во втором параметре (методе аутентификации)
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction(controllerName: "Home", actionName: "Index");
                }
                else
                    foreach (var identityError in createResult.Errors)
                        ModelState.AddModelError("", identityError.Description);

            }

            return View(userModel);
        }

        // Вопрос по 2-му атрибуту
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(controllerName: "Home", actionName: "Index");
        }
    }
}