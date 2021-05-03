using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
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
        // view with all dreams in database
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

        // // dreams for logged in person
        // public IActionResult Index(int userId)
        // {
        //     DreamLogicControllerFactory dreamLogicControllerFactory = new();
        //     IDreamLogicController dreamLogicController = dreamLogicControllerFactory.DreamLogicController();
        //     List<DreamViewModel> viewDreams = new();
        //     List<DreamLogicModel> logicDreams = dreamLogicController.GetDreamsByUserId(userId);
        //     foreach (var logicDream in logicDreams)
        //     {
        //         DreamViewModel newViewDream = new(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story);
        //         viewDreams.Add(newViewDream);
        //     }
        //     return View(viewDreams);
        // }

        // shows the view for creating a new dream
        public IActionResult Create()
        {
            return View();
        }

        // adds a dream when user posts data
        [HttpPost]
        public IActionResult Create(int id, int userId, string title, string story)
        {
            DreamLogicControllerFactory dreamLogicControllerFactory = new();
            IDreamLogicController dreamLogicController = dreamLogicControllerFactory.DreamLogicController();
            DreamLogicModel logicDream = new(id, userId, title, story);
            dreamLogicController.AddDream(logicDream);
            return RedirectToAction(nameof(Index));
        }

        // deletes dream
        public IActionResult Delete(int id)
        {
            DreamLogicControllerFactory dreamLogicControllerFactory = new();
            IDreamLogicController dreamLogicController = dreamLogicControllerFactory.DreamLogicController();
            dreamLogicController.RemoveDream(id);

            return RedirectToAction(nameof(Index));
        }

        // // view for details
        // public IActionResult Details()
        // {
        //     return View();
        // }

        // view for details of specific dream
        public IActionResult Details(int id)
        {
            DreamLogicControllerFactory dreamLogicControllerFactory = new();
            IDreamLogicController dreamLogicController = dreamLogicControllerFactory.DreamLogicController();
            DreamLogicModel dataDream = dreamLogicController.GetDreamById(id);
            DreamViewModel viewDream = new(dataDream.Id, dataDream.UserId, dataDream.Title, dataDream.Story);
            return View(viewDream);
        }
    }
}
