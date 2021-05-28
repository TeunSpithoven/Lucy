using System.Collections.Generic;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using View.Mappers;
using View.Models;

namespace View.Controllers
{
    public class DreamController : Controller
    {
        private readonly IDreamLogic _dreamLogic;

        public DreamController(IDreamLogic dreamLogic)
        {
            _dreamLogic = dreamLogic;
        }

        // view with all dreams in database
        public IActionResult Index()
        {
            List<DreamLogicModel> logicDreams = _dreamLogic.GetDreams();
            List<DreamViewModel> viewDreams = new();
            
            foreach (var logicDream in logicDreams)
            {
                DreamViewModel newViewDream = DreamViewMapper.LogicToViewDreamModel(logicDream);
                viewDreams.Add(newViewDream);
            }
            return View(viewDreams);
        }

        // // dreams for logged in person
        // public IActionResult Index(int userId)
        // {
        //     List<DreamViewModel> viewDreams = new();
        //     List<DreamLogicModel> logicDreams = _dreamLogic.GetDreamsByUserId(userId);
        //     foreach (var logicDream in logicDreams)
        //     {
        //         DreamViewModel newViewDream = new(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story, logicDream.CreationDateTime);
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
            DreamLogicModel logicDream = new(id, userId, title, story);
            _dreamLogic.AddDream(logicDream);
            return RedirectToAction(nameof(Index));
        }

        // deletes dream
        public IActionResult Delete(int id)
        {
            _dreamLogic.RemoveDream(id);
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
            DreamLogicModel logicDream = _dreamLogic.GetDreamById(id);
            DreamViewModel viewDream = DreamViewMapper.LogicToViewDreamModel(logicDream);
            return View(viewDream);
        }
    }
}
