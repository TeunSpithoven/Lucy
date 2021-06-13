using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using View;
using View.Mappers;
using View.Models;

namespace View.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentLogic _commentLogic;
        
        public CommentController(ICommentLogic commentLogic)
        {
            _commentLogic = commentLogic;
        }
        
        public IActionResult Index()
        {
            List<CommentLogicModel> logicComments = _commentLogic.GetAll();
            List<CommentViewModel> viewComments = new();
        
            foreach (var logicComment in logicComments)
            {
                CommentViewModel newViewRequest = CommentViewMapper.LogicToViewCommentModel(logicComment);
                viewComments.Add(newViewRequest);
            }
            return View(viewComments);
        }
        
        // GET: Request/Create
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(int userId, string message, int dreamId)
        {
            _commentLogic.Create(message, userId, dreamId);
            return RedirectToAction(nameof(Index));
        }
    }
}
