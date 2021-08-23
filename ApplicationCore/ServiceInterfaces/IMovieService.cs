using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<List<MovieCardResponseModel>> GetTopRevenueMovies();

        Task<MovieDetailsResponseModel> GetMovieDetails(int Id);
        Task<List<MovieCardResponseModel>> GetAllMovies();
        Task<MovieCardResponseModel> GetMovieById(int Id);
        Task<List<MovieCardResponseModel>> GetTopRatedMovies();
        Task<List<ReviewResponseModel>> GetMovieReviews(int Id);
    }
}
