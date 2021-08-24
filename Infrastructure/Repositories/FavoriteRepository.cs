using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FavoriteRepository : EfRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Favorite>> GetAllFavorites(int id)
        {
            var favorites = await _dbContext.Favorites.Where(f => f.UserId == id).ToListAsync();
            if (!favorites.Any())
            {
                throw new Exception($"No Favorites Found with {id}");
            }
            return favorites;
        }
        //public async Task<Movie> GetUnFavoritedMovieById(int movieId, int userId)
        //{
        //    var favorite = await _dbContext.Favorites.Include(f => f.Movie).FirstOrDefaultAsync(f => f.MovieId == movieId && f.UserId == userId);
        //    return favorite == null ? null : favorite.Movie;
        //}

    }
}
