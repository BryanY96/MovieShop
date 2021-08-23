using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        // empty page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            // Cookie-based Authentication
            //
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userService.Login(model);

            if (user == null)
            {
                //return View();
                throw new Exception("Invalid Login");
            }

            // store some information in the Cookies, Authentication cookie.. Claims
            // 
            var claims = new List<Claim>
            {
                new Claim(type:ClaimTypes.Email, value:user.Email),
                new Claim(type:ClaimTypes.GivenName, value:user.FirstName),
                new Claim(type:ClaimTypes.Surname, value:user.LastName),
                new Claim(type:ClaimTypes.NameIdentifier, value:user.Id.ToString())
            };
            // Identity class .. and Principle
            // go to an bar => check your identity => Driver License
            // go to Airport => check passport
            // Create a movie => claim with role value as Admin

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // create the cookies
            // HttpContext

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            // Cookies based authentication ....

            //return View();
            return LocalRedirect("~/");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            if (!ModelState.IsValid) // safety check, prevent invalid input stored in database
            {
                return View();
            }
            // call the service and repository to hash the password with salt and save to DB

            var registeredUser = await _userService.RegisterUser(model);
            return RedirectToAction("Login");
        }

    }
}
