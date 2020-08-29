using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Trululu.web.Data;
using Trululu.web.Entities;
using Trululu.web.Filters;
using Trululu.web.ViewModels;

namespace Trululu.web.Controllers
{
    public class CastingController : Controller
    {
        private readonly ICastingRepository _castingRepository;

        public CastingController(ICastingRepository castingRepository)
        {
            _castingRepository = castingRepository;
        }

        private int getIdCurrentUser()
        {
            var userClaimIdentity = User.Identity as ClaimsIdentity;
            int userId = int.Parse(userClaimIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);

            return userId;
        }

        public IActionResult Index()
        {
            var castings = _castingRepository.FindAll();

            return View(castings);
        }

        public IActionResult Details(int id)
        {
            Casting casting = _castingRepository.FindById(id);

            return View(casting);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            return View(new CastingViewModel());
        }

        [HttpPost]
        [LogFilter]
        public IActionResult Add(CastingViewModel castingViewModel)
        {
            if (ModelState.IsValid)
            {
                Casting casting = new Casting();
                casting.NewFromForm(castingViewModel);

                casting.CreatorId = getIdCurrentUser();
                _castingRepository.Add(casting);

                return RedirectToAction("Index", "Account");
            }

            return View(castingViewModel);
        }

        [Authorize]
        public IActionResult Remove(int id)
        {
            Casting casting = _castingRepository.FindById(id);
            if (casting.CreatorId == getIdCurrentUser())
            {
                _castingRepository.Remove(casting);
            }

            return RedirectToAction("Index", "Account");
        }
    }
}

