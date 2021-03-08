using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucy.Data;
using Lucy.Models;

namespace Lucy.Controllers
{
    public class DreamController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DreamController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult AddDream()
        {
            IEnumerable<Dream> objList = _db.Dream;
            return View(objList);
        }

        public IActionResult DreamList()
        {
            IEnumerable<Dream> objList = _db.Dream;
            return View(objList);
        }

        public IActionResult EditDream()
        {
            IEnumerable<Dream> objList = _db.Dream;
            return View(objList);
        }

        public IActionResult DeleteDream()
        {
            IEnumerable<Dream> objList = _db.Dream;
            return View(objList);
        }
    }
}
