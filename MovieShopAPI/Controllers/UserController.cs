using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IReviewService _reviewService;
        private readonly ICurrentUserService _currentUserService;

        public UserController(IUserService userService, IReviewService reviewService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _reviewService = reviewService;
            _currentUserService = currentUserService;
        }

        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> BuyMovie(int movieId)
        {
            if (!_currentUserService.IsAuthenticated)
            {
                return Unauthorized("Need to login first!");
            }
            var movie = await _userService.BuyMovie(movieId);
            return Ok(movie);
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> Favorite([FromBody] int movieId)
        {
            var result = await _userService.AddToFavorite(movieId);
            return Ok(result);
        }
    }
}
