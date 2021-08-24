using ApplicationCore.Models;
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
        //private readonly IReviewService _reviewService;
        private readonly ICurrentUserService _currentUserService;
        

        public UserController(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            //_reviewService = reviewService;
            _currentUserService = currentUserService;
        }

        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> BuyMovie([FromBody] PurchaseRequestModel model)
        {
            if (!_currentUserService.IsAuthenticated)
            {
                return Unauthorized("Need to login first!");
            }
            var movie = await _userService.BuyMovie(model);
            if (movie == null)
            {
                return BadRequest("Purchase Failed");
            }
            return Ok(movie);
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> Favorite([FromBody] FavoriteRequestModel model)
        {
            if (!_currentUserService.IsAuthenticated)
            {
                return Unauthorized("Need to login first!");
            }
            var movie = await _userService.AddToFavorite(model);
            if (movie == null)
            {
                return BadRequest("Add to Favorite failed");
            }
            return Ok(movie);
        }
        [HttpPost]
        [Route("unfavorite")]
        public async Task<IActionResult> UnFavorite(UnfavoriteModel model)
        {
            if (!_currentUserService.IsAuthenticated)
            {
                return Unauthorized("Need to login first!");
            }
            var movie = await _userService.RemoveFromFavorite(model);
            if (movie == null)
            {
                return BadRequest("Unfavorite movie failed");
            }
            return Ok(movie);
        }

        [HttpGet]
        [Route("{id:int}/movie/{movieId}/favorite")]
        public async Task<IActionResult> IsFavoriteExists(int id, int movieId)
        {
            var favoriteExists = await _userService.IsFavoriteExists(id, movieId);
            return Ok(new { isFavorited = favoriteExists });
        }
        [HttpGet]
        [Route("{id:int}/purchases")]
        public async Task<IActionResult> GetAllPurchases(int id)
        {
            var movies = await _userService.GetPuchasedMovies(id);
            if (!movies.Any())
            {
                NotFound("No purchased movies found");
            }
            return Ok(movies);
        }
        [HttpGet]
        [Route("{id:int}/favorites")]
        public async Task<IActionResult> GetAllFavorites(int id)
        {
            var movies = await _userService.GetFavoriteMovies(id);
            if (!movies.Any())
            {
                NotFound("No favorite movies found");
            }
            return Ok(movies);
        }

        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> WriteReview([FromBody] ReviewRequestModel model)
        {
            
            if (!_currentUserService.IsAuthenticated)
            {
                return Unauthorized("Need to login first!");
            }
            var review = await _userService.WriteReview(model);
            if (review == null)
            {
                return BadRequest("Write Review Failed");
            }
            return Ok(review);
        }

        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> UpdateReview([FromBody] ReviewRequestModel model)
        {
            if (!_currentUserService.IsAuthenticated)
            {
                return Unauthorized("Need to login first!");
            }
            var review = await _userService.UpdateReview(model);
            if (review == null)
            {
                return BadRequest("Update Review Failed");
            }
            return Ok(review);
        }

        [HttpDelete]
        [Route("{userId:int}/movie/{movieId:int}")]
        public async Task<IActionResult> DeleteReview(int userId, int movieId)
        {
            if (!_currentUserService.IsAuthenticated)
            {
                return Unauthorized("Need to login first!");
            }
            var review = await _userService.DeleteReview(userId, movieId);
            if (review == null)
            {
                return BadRequest("Delete Review Failed");
            }
            return Ok(review);
        }
        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetReviews(int id)
        {
            var reviews = await _userService.GetReviews(id);
            if (!reviews.Any())
            {
                return NotFound($"No reviews found for this userId: {id}");
            }
            return Ok(reviews);
        }
    }
}
