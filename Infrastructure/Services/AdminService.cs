using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        public AdminService(IMovieRepository movieRepository, IPurchaseRepository purchaseRepository)
        {
            _movieRepository = movieRepository;
            _purchaseRepository = purchaseRepository;
        }

        public async Task<MovieCreateResponseModel> CreateMovie(MovieCreateRequestModel model)
        {
            var dbMovie = await _movieRepository.GetByIdAsync(model.Id);
            if (dbMovie != null)
            {
                throw new ConflictException("This movie already exists");
            }
            var movie = new Movie
            {
                Id = model.Id,
                Title = model.Title,
                Overview = model.Overview,
                Tagline = model.Tagline,
                Budget = model.Budget,
                Revenue = model.Revenue,
                ImdbUrl = model.ImdbUrl,
                TmdbUrl = model.TmdbUrl,
                PosterUrl = model.PosterUrl,
                BackdropUrl = model.BackdropUrl,
                OriginalLanguage = model.OriginalLanguage,
                ReleaseDate = model.ReleaseDate,
                RunTime = model.RunTime,
                Price = model.Price
            };
            var createdMovie = await _movieRepository.AddAsync(movie);
            return new MovieCreateResponseModel
            {
                MovieId = createdMovie.Id,
                Title = createdMovie.Title
            };
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchases()
        {
            return await _purchaseRepository.ListAllAsync();
        }

        public async Task<MovieCreateResponseModel> UpdateMovie(MovieCreateRequestModel model)
        {
            var dbMovie = await _movieRepository.GetByIdAsync(model.Id);
            if (dbMovie == null)
            {
                throw new ConflictException("This movie doesn't exist");
            }
            var movie = new Movie
            {
                Id = model.Id,
                Title = model.Title,
                Overview = model.Overview,
                Tagline = model.Tagline,
                Budget = model.Budget,
                Revenue = model.Revenue,
                ImdbUrl = model.ImdbUrl,
                TmdbUrl = model.TmdbUrl,
                PosterUrl = model.PosterUrl,
                BackdropUrl = model.BackdropUrl,
                OriginalLanguage = model.OriginalLanguage,
                ReleaseDate = model.ReleaseDate,
                RunTime = model.RunTime,
                Price = model.Price
            };
            var updatedMovie = await _movieRepository.UpdateAsync(movie);
            return new MovieCreateResponseModel
            {
                MovieId = updatedMovie.Id,
                Title = updatedMovie.Title
            };
        }
    }
}
