using System.Collections.Generic;
using Logic.Factories;
using Logic.Interfaces;
using Logic.Models;
using LogicDataConnector.Factories;
using LogicDataConnector.Interfaces;
using Microsoft.AspNetCore.Mvc;
using View.Mappers;
using View.Models;

namespace View.Controllers
{
    public class DreamController : Controller
    {
        private readonly DreamLogicFactory _logicFactory = new();
        private readonly DreamDataFactory _dataFactory = new();
        private IDreamConnector _dreamData;

        // view with all dreams in database
        public IActionResult Index()
        {
            _dreamData = _dataFactory.DreamSqlData();
            IDreamLogic dreamLogicController = _logicFactory.DreamLogic(_dreamData);

            List<DreamLogicModel> logicDreams = dreamLogicController.GetDreams();
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
            _dreamData = _dataFactory.DreamSqlData();
            IDreamLogic dreamLogicController = _logicFactory.DreamLogic(_dreamData);
            DreamLogicModel logicDream = new(id, userId, title, story);
            dreamLogicController.AddDream(logicDream);
            return RedirectToAction(nameof(Index));
        }

        // deletes dream
        public IActionResult Delete(int id)
        {
            _dreamData = _dataFactory.DreamSqlData();
            IDreamLogic dreamLogic = _logicFactory.DreamLogic(_dreamData);
            dreamLogic.RemoveDream(id);

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
            _dreamData = _dataFactory.DreamSqlData();
            IDreamLogic dreamLogicController = _logicFactory.DreamLogic(_dreamData);
            DreamLogicModel logicDream = dreamLogicController.GetDreamById(id);
            DreamViewModel viewDream = DreamViewMapper.LogicToViewDreamModel(logicDream);
            return View(viewDream);
        }
    }
}
