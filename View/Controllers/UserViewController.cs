using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Controllers;
using Logic.Models;
using View.Models;

namespace View.Controllers
{
    public class UserViewController : Controller
    {
        public bool IsLoggedIn(UserViewModel viewUser)
        {
            UserLogicModel logicUser = new(viewUser.Id, viewUser.Username, viewUser.Password, viewUser.LoggedIn);
            UserLogicController d = new();
            bool isLoggedIn = d.IsLoggedIn(logicUser);
            return isLoggedIn;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
