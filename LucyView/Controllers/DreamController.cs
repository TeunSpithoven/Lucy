using Lucy5.Data;
using Lucy5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Lucy5.Controllers
{
    public class DreamController : Controller
    {
        private readonly ApplicationDbContext _db;
        private DreamData dreamData;

        public DreamController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult DreamList()
        {
            // haalt lijst van alle dromen uit database
            IEnumerable<Dream> dreams = _db.Dream;
            return View(dreams);
        }

        public IActionResult Delete(int id)
        {
            dreamData = new DreamData();
            dreamData.RemoveDreamFromDatabase(id);
            List<Dream> dreams = dreamData.GetDreamsFromDatabase();
            return RedirectToAction("DreamList", dreams);
        }

        public IActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult AddDream()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDream(string title, string story)
        {
            dreamData = new DreamData();
            Dream newDream = new Dream(title, story);
            dreamData.AddDreamToDatabase(newDream);
            return View();
        }
    }
}