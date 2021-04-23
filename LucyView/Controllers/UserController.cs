using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lucy5.Data;
using Lucy5.Models;

namespace Lucy5.Controllers
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
