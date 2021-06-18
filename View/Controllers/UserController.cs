using System;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace View.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(int id, string username, string password)
        {
            _userLogic.Create(id, username, password);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
