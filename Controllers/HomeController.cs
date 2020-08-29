using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trululu.web.Filters;
using Trululu.web.ViewModels;

namespace Trululu.web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Feedback()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Feedback(FeedbackViewModel feedbackViewModel)
        {
            return View(feedbackViewModel);
        }
    }
}