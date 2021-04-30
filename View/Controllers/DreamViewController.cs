using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Factories;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using View.Models;

namespace View.Controllers
{
    public class DreamViewController : Controller
    {
        public IActionResult Index()
        {
            DreamLogicControllerFactory dreamLogicControllerFactory = new();
            IDreamLogicController dreamLogicController = dreamLogicControllerFactory.DreamLogicController();
            List<DreamViewModel> viewDreams = new();
            List<DreamLogicModel> logicDreams = dreamLogicController.GetDreams();
            foreach (var logicDream in logicDreams)
            {
                DreamViewModel newViewDream = new(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story);
                viewDreams.Add(newViewDream);
            }
            return View(viewDreams);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id, int userId, string title, string story)
        {
            DreamLogicControllerFactory dreamLogicControllerFactory = new();
            IDreamLogicController dreamLogicController = dreamLogicControllerFactory.DreamLogicController();
            DreamLogicModel logicDream = new(id, userId, title, story);
            dreamLogicController.AddDream(logicDream);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            DreamLogicControllerFactory dreamLogicControllerFactory = new();
            IDreamLogicController dreamLogicController = dreamLogicControllerFactory.DreamLogicController();
            dreamLogicController.RemoveDream(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details()
        {
            throw new NotImplementedException();
        }

        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var dreamViewModel = await _context.DreamViewModel
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (dreamViewModel == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return View(dreamViewModel);
        // }
    }
}
