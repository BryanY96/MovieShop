using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserPurchasedById(int id);
        Task<User> GetUserFavoriteById(int id);
        Task<Movie> GetPurchasedMovieById(int movieId, int userId);
        Task<Movie> GetFavoritedMovieById(int movieId, int userId);
        
    }
}
