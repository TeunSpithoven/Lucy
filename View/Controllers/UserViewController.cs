﻿using Microsoft.AspNetCore.Mvc;

namespace View.Controllers
{
    public class UserViewController : Controller
    {
        // public bool IsLoggedIn(UserViewModel viewUser)
        // {
        //     UserLogicModel logicUser = new(viewUser.Id, viewUser.Username, viewUser.Password, viewUser.LoggedIn);
        //     UserLogic d = new();
        //     bool isLoggedIn = d.IsLoggedIn(logicUser);
        //     return isLoggedIn;
        // }

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
