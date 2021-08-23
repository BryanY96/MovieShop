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
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        // ctor "tab tab"
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<Movie>> Get30HighestRevenueMovies()
        {
            // get 30 movies from movie table order by revenue
            // ToList(), Count() or we can loop through -- execute linq query
            // I/O bound operation 
            // EF has methods that have both asy and non-async ones   
            
            // SQL Query: select top 30 from movies order by revenue;
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();

            return movies;
        }
        //public override Task<IEnumerable<Movie>> ListAllAsync()
        //{
        //    var movies = await _dbContext.Movies.ToListAsync();
        //}
        

        public override async Task<Movie> GetByIdAsync(int Id)
        {
            // movie table, then genres, then casts and rating
            // Include() ThenInclude()

            var movie = await _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast).Include(m => m.Genres)
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (movie == null)
            {
                throw new Exception("No movie found for the id {Id}");
            }

            var movieRating = await _dbContext.Reviews.Where(m => m.MovieId == Id).DefaultIfEmpty()
                .AverageAsync(r => r == null ? 0 : r.Rating); // if condition: if r is null, return 0, otherwise, return the rating

            movie.Rating = movieRating;
            return movie;
        }
    }
}
