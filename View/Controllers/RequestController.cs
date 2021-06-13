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
    public class RequestController : Controller
    {
        private readonly IRequestLogic _requestLogic;

        public RequestController(IRequestLogic requestLogic)
        {
            _requestLogic = requestLogic;
        }

        public IActionResult Index()
        {
            List<RequestLogicModel> logicRequests = _requestLogic.GetAll();
            List<RequestViewModel> viewRequests = new();

            foreach (var logicRequest in logicRequests)
            {
                RequestViewModel newViewRequest = RequestViewMapper.LogicToViewRequestModel(logicRequest);
                viewRequests.Add(newViewRequest);
            }
            return View(viewRequests);
        }

        // GET: Request/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int user1, int user2)
        {
            _requestLogic.Create(user1, user2);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Accept(int id)
        {
            _requestLogic.Accept(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deny(int id)
        {
            _requestLogic.Deny(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
