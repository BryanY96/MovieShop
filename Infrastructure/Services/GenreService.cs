using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMemoryCache _memoryCache;
        
        // Caching...
        // Genres...
        // key/value
        // genres/List<Genres> expiration time

        public GenreService(IGenreRepository genreRepositry, IMemoryCache memoryCache)
        {
            _genreRepository = genreRepositry;
            _memoryCache = memoryCache;
        }
        public async Task<IEnumerable<GenreResponseModel>> GetAllGenres()
        {
            // check if the cache has the genres, if yes then take genres from cache
            // If No, then go to database and get the genres and store in cache
            // .NET In Memory Caching => smaller amount of data
            // Distributed caching -> Redis Cache => Large amount of data

            var genres = await _memoryCache.GetOrCreateAsync("genresData", async entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromDays(30);
                return await _genreRepository.ListAllAsync();
            });

            // var genres = await _genreRepository.ListAllAsync();
            var genresModel = new List<GenreResponseModel>();

            foreach (var genre in genres)
            {
                genresModel.Add(new GenreResponseModel { Id = genre.Id, Name = genre.Name });
            }
            return genresModel;
        }

        public async Task<GenreResponseModel> GetGenreDetails(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            var genreDetails = new GenreResponseModel()
            {
                Id = genre.Id,
                Name = genre.Name
            };

            genreDetails.Movies = new List<MovieCardResponseModel>();
            foreach (var movie in genre.Movies)
            {
                genreDetails.Movies.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }

            return genreDetails;
        }


        //public async Task<IEnumerable<MovieCardResponseModel>> GetAllMovies(int id)
        //{
        //    var genre = await _genreRepository.GetMoviesByGenreId(id);
        //    var movieCards = new List<MovieCardResponseModel>();

        //    foreach (var movie in genre.Movies)
        //    {
        //        movieCards.Add(new MovieCardResponseModel
        //        {
        //            Id = movie.Id,
        //            Title = movie.Title,
        //            PosterUrl = movie.PosterUrl,
        //        });
        //    }

        //    return movieCards;
        //}

        //public async Task<Genre> GetGenreById
    }
}
