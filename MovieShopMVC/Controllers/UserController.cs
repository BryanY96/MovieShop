using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {   
        // user / GetALlPurchases
        
        public async Task<IActionResult> GetAllPurchases()
        {
            //var userid = HttpContext.User.Claims.Where(c => c.Type == ClaimType.NameIdentifier).FirstOrDefault();
            // id from the cookie and send that if to UserService to get all his/her movies
            // Filters
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetFavorites()
        {
            return View();
        }

      
        public async Task<IActionResult> EditProfile()
        {
            return View();
        }

    }
}
