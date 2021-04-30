using System;
using View.Data;
using Microsoft.AspNetCore.Mvc;

namespace LucyFrontEnd.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }

        public IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}
