using System;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace View.Controllers
{
    public class UserViewController : Controller
    {
        private readonly IUserLogic _userLogic;

        public UserViewController(IUserLogic userLogic)
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
            UserLogicModel logicUser = new(id, username, password, false, DateTime.Now);
            _userLogic.Create(logicUser);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
