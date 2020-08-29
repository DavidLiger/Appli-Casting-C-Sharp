using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
    public class SecurityController : Controller
    {
        private readonly IUserRepository _userRepository;

        public SecurityController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private IEnumerable<Claim> GetRoleClaims(User user)
        {
            yield return new Claim(ClaimTypes.Role, user.Role);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        [LogFilter]
        public async Task<IActionResult> SignInAsync(SignInViewModel signinViewModel)
        {
            if (ModelState.IsValid)
            {
                User userFind = _userRepository.FindByAuth(signinViewModel.Mail, signinViewModel.Password);

                if (null != userFind)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Sid, userFind.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, userFind.Mail)
                    };
                    claims.AddRange(GetRoleClaims(userFind));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Signin", "Security");
            }
            return View(signinViewModel);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new SignUpViewModel());
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel signUpViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.signUp(signUpViewModel);

                _userRepository.Add(user);
                return RedirectToAction("Signin", "Security");
            }
            return View(signUpViewModel);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Signin", "Security");
        }
    }
}
