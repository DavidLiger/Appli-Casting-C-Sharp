using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Trululu.web.Data;
using Trululu.web.Entities;
using Trululu.web.ViewModels;

namespace Trululu.web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICastingRepository _castingRepository;

        public AccountController(ICastingRepository castingRepository)
        {
            _castingRepository = castingRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var context = new TruluDbContext();
            var userClaimIdentity = User.Identity as ClaimsIdentity;
            int userId = int.Parse(userClaimIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);

            var user = context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefault<User>();

            IEnumerable<Casting> castings = _castingRepository.FindByCreator(user.Id);

            ProfileViewModel viewModel = new ProfileViewModel
            {
                user = user,
                castings = castings
            };

            return View(viewModel);
        }
    }
}
