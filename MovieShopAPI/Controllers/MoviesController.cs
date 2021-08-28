using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace MovieShopAPI.Controllers
{
    // Attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        public MoviesController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }
        // api/movies/toprevenue
        [Route("toprevenue")]
        [HttpGet]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetTopRevenueMovies();
            if (!movies.Any())
            {
                return NotFound("No Movies Found");
            }
            // 200 OK
            return Ok(movies);
            // Serialization => object to another type of object
            // C# to JSON
            // C# to XML using XMLSerializer
            // DeSerialization => JSON to C#
            // .NET Core 3.1 or less => JSON.NET => 3rd party library, included

            // along with data you also need to return HTTP status code
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();
            if (!movies.Any())
            {
                NotFound("No movies exist");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null)
            {
                NotFound($"No movie found with id {id}");
            }
            return Ok(movie);
        }

        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movies = await _movieService.GetTopRatedMovies();
            if (!movies.Any())
            {
                NotFound("No movies exist");
            }
            return Ok(movies);
        }
        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreId)
        {
            var genreDetails = await _genreService.GetGenreDetails(genreId);
            var movies = genreDetails.Movies;
            if (!movies.Any())
            {
                NotFound($"No movies found with genreId: {genreId}");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetMovieReviews(int id)
        {
            var reviews = await _movieService.GetMovieReviews(id);
            if (!reviews.Any())
            {
                NotFound($"No reviews found for movieId: {id}");
            }
            return Ok(reviews);
        }

    }
}
