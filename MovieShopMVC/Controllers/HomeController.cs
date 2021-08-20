using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        public async Task<IActionResult> Index()
        {
            //throw new System.Exception("some error occured");
            var movieCards = await _movieService.GetTopRevenueMovies();
            return View(movieCards);

            // 2 ways to pass data from controller to view
            // 1 Strongly Typed Models
            // 2 ViewBag
            // 3 ViewData
            // get top revenue movies and display on the view
            // localhost:5001/movies/details/2

            //ViewBag.PageTitle = "Top Revenue Movie";  // ViewBag is a dynamic method (not strongly typed models)
            //ViewData["TotalMovies"] = movies.Count();


            //return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
