using System;
using System.Collections.Generic;
using View.Data;
using LucyFrontEnd.Models;
using Lucy5.Models;
using Microsoft.AspNetCore.Mvc;
using Lucy5.Logic;

namespace View.Controllers
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
            dreamData.DeleteDreamFromDB(id);
            List<Dream> dreams = dreamData.GetDreamListFromDB();
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
            DreamData dreamData = new DreamData();
            Dream newDream = new Dream(title, story);
            dreamData.AddDreamToDB(newDream);
            return View();
        }
    }
}