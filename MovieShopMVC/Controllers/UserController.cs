using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using ApplicationCore.ServiceInterfaces;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ICurrentUserService _currentService;
        private readonly IUserService _userService;
        public UserController(ICurrentUserService currentUserService, IUserService userService)
        {
            _currentService = currentUserService;
            _userService = userService;
        }

        // user / GetALlPurchases
        
        public async Task<IActionResult> GetAllPurchases()
        {
            var userId = _currentService.UserId;
            var movieCards = await _userService.GetPuchasedMovies(userId);
            return View(movieCards);
        }
        
        public async Task<IActionResult> GetFavorites()
        {
            var userId = _currentService.UserId;
            var movieCards = await _userService.GetFavoriteMovies(userId);
            return View(movieCards);
        }

        public async Task<IActionResult> GetProfile()
        {
            return View();
        }

        public async Task<IActionResult> EditProfile()
        {
            return View();
        }

        public async Task<IActionResult> BuyMovie()
        {
            return View();
        }

        public async Task<IActionResult> FavoriteMovie()
        {
            return View();
        }
    }
}
