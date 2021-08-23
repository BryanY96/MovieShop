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
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
        public async Task<User> GetUserFavoriteById(int id)
        {
            return await _dbContext.Users.Include(u => u.Favorites).ThenInclude(u => u.Movie).FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<User> GetUserPurchasedById(int id)
        {
            return await _dbContext.Users.Include(u => u.Purchases).ThenInclude(u => u.Movie).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Movie> GetPurchasedMovieById(int movieId, int userId)
        {
            var purchase = await _dbContext.Purchases.Include(p => p.Movie).FirstOrDefaultAsync(p => p.MovieId == movieId && p.UserId == userId);
            return purchase == null ? null : purchase.Movie;
        }
    }
}
