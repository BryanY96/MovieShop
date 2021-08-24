using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMovieRepository _movieRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IReviewRepository _reviewRepository;
        public UserService(IUserRepository userRepository, ICurrentUserService currentUserService, 
            IMovieRepository movieRepository, IPurchaseRepository purchaseRepository, IFavoriteRepository favoriteRepository, IReviewRepository reviewRepository)
        {
            _userRepository = userRepository;
            _currentUserService = currentUserService;
            _movieRepository = movieRepository;
            _purchaseRepository = purchaseRepository;
            _favoriteRepository = favoriteRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetFavoriteMovies(int userId)
        {
            var user = await _userRepository.GetUserFavoriteById(userId);
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in user.Favorites)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.MovieId,
                    Title = movie.Movie.Title,
                    PosterUrl = movie.Movie.PosterUrl
                });
            }
            return movieCards;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetPuchasedMovies(int userId)
        {
            var user = await _userRepository.GetUserPurchasedById(userId);
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in user.Purchases)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.MovieId,
                    Title = movie.Movie.Title,
                    PosterUrl = movie.Movie.PosterUrl
                });
            }
            return movieCards;

        }

        public async Task<UserLoginResponseModel> Login(LoginRequestModel model)
        {
            var dbUser = await _userRepository.GetUserByEmail(model.Email);
            if (dbUser == null)
            {
                return null;
            }

            // get the hashed password and salt from database

            var hashedPassword = GetHashedPassword(model.Password, dbUser.Salt);
            if (hashedPassword == dbUser.HashedPassword)
            {
                // success
                var userLoginResponseModel = new UserLoginResponseModel
                {
                    Id = dbUser.Id,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    Email = dbUser.Email
                };

                return userLoginResponseModel;
            }
            return null;
            
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel model)
        {
            // make sure with the user entered email does not exists in database
            var dbUser = await _userRepository.GetUserByEmail(model.Email);
            if (dbUser != null)
            {
                // user already has email
                throw new ConflictException("Email already exists");
            }

            // user does not exists in the database

            // generate a unique salt
            var salt = GenerateSalt();
            var hashedPassword = GetHashedPassword(model.Passsword, salt);
            // hash password with salt
            // save the salt and hashed password to the database.

            // create user entity object
            var user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Salt = salt,
                HashedPassword = hashedPassword
            };

            var createdUser = await _userRepository.AddAsync(user);

            var userRegisterResponseModel = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };

            return userRegisterResponseModel;
        }

        //public async Task<UserResponseModel> GetUserById(int id)
        //{
        //    var user = await _userRepository.GetByIdAsync(id);

        //    var userResponseModel = new UserResponseModel()
        //    {
        //        Id = user.Id,
        //        Email = user.Email,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        DateOfBirth = user.DateOfBirth
        //    };
        //    return userResponseModel;
        //}

        public async Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {
            var users = await _userRepository.ListAllAsync();
            var userList = new List<UserResponseModel>();
            foreach (var user in users)
            {
                userList.Add(new UserResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth
                });
            }
            return userList;
        }

        public async Task<PurchaseResponseModel> BuyMovie(PurchaseRequestModel model)
        {
            var purchasedMovie = await _userRepository.GetPurchasedMovieById(model.MovieId, model.UserId);
            if (purchasedMovie != null)
            {
                throw new ConflictException("You already bought this movie before");
            }
            
            var purchaseMovie = new Purchase
            {
                UserId = model.UserId,
                MovieId = model.MovieId,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = model.TotalPrice,
                PurchaseDateTime = DateTime.Now
            };
            var createdPurchase = await _purchaseRepository.AddAsync(purchaseMovie);
            return new PurchaseResponseModel
            {
                Id = createdPurchase.Id,
                MovieId = createdPurchase.MovieId,
                UserId = createdPurchase.UserId,
                TotalPrice = createdPurchase.TotalPrice,
                PurchaseDateTime = createdPurchase.PurchaseDateTime,
                PurchaseNumber = createdPurchase.PurchaseNumber
            };
        }

        public async Task<FavoriteResponseModel> AddToFavorite(FavoriteRequestModel model)
        {
            var favoritedMovie = await _userRepository.GetFavoritedMovieById(model.MovieId, model.UserId);
            if (favoritedMovie != null)
            {
                throw new ConflictException("You already added this movie before");
            }
            var movie = await _movieRepository.GetByIdAsync(model.MovieId);
            var favoriteMovie = new Favorite
            {
                UserId = model.UserId,
                MovieId = model.UserId
            };
            var createdFavorite = await _favoriteRepository.AddAsync(favoriteMovie);
            return new FavoriteResponseModel
            {
                Id = createdFavorite.Id,
                MovieId = createdFavorite.MovieId,
                UserId = createdFavorite.UserId
            };
        }
        public async Task<UnfavoriteModel> RemoveFromFavorite(UnfavoriteModel model)
        {
            //var dbFav = await _favoriteRepository.ListAsync(r => r.UserId == model.UserId && r.MovieId == model.MovieId);
            //await _favoriteRepository.DeleteAsync(dbFav.First());

            var unfavoritedMovie = await _favoriteRepository.GetExistAsync(f => f.Id == model.Id);
            if (!unfavoritedMovie)
            {
                throw new ConflictException("You haven't added this movie to favorite yet!");
            }
            
            var favoriteMovie = new Favorite
            {
                Id = model.Id,
                UserId = model.UserId,
                MovieId = model.MovieId
            };
            await _favoriteRepository.DeleteAsync(favoriteMovie);
            return model;
        }

        public async Task<bool> IsFavoriteExists(int id, int movieId)
        {
            return await _favoriteRepository.GetExistAsync(f => f.MovieId == movieId && f.UserId == id);
        }
        public async Task<ReviewResponseModel> WriteReview(ReviewRequestModel model)
        {
            var hasReview = await _reviewRepository.GetExistAsync(r => r.MovieId == model.MovieId && r.UserId == model.UserId);
            if (hasReview)
            {
                throw new ConflictException("you've already written view for this movie before");
            }
            var review = new Review
            {
                UserId = model.UserId,
                MovieId = model.MovieId,
                ReviewText = model.ReviewText,
                Rating = model.Rating
            };
            var writtenReview = await _reviewRepository.AddAsync(review);
            return new ReviewResponseModel 
            { 
                UserId = writtenReview.UserId,
                MovieId = writtenReview.MovieId,
                ReviewText = writtenReview.ReviewText,
                Rating = writtenReview.Rating
            };
        }
        public async Task<ReviewResponseModel> UpdateReview(ReviewRequestModel model)
        {
            var hasReview = await _reviewRepository.GetExistAsync(r => r.MovieId == model.MovieId && r.UserId == model.UserId);
            if (!hasReview)
            {
                throw new ConflictException("You haven't written review for this movie yet");
            }
            var review = new Review
            {
                UserId = model.UserId,
                MovieId = model.MovieId,
                ReviewText = model.ReviewText,
                Rating = model.Rating
            };
            var updatedReview = await _reviewRepository.UpdateAsync(review);
            return new ReviewResponseModel
            {
                UserId = updatedReview.UserId,
                MovieId = updatedReview.MovieId,
                ReviewText = updatedReview.ReviewText,
                Rating = updatedReview.Rating
            };
        }
        public async Task<ReviewResponseModel> DeleteReview(int userId, int movieId)
        {
            var hasReview = await _reviewRepository.GetExistAsync(r => r.MovieId == movieId && r.UserId == userId);
            if (!hasReview)
            {
                throw new ConflictException("You haven't written review for this movie yet");
            }
            var review = new Review
            {
                UserId = userId,
                MovieId = movieId
            };
            var deletedReview = await _reviewRepository.DeleteAsync(review);
            return new ReviewResponseModel
            {
                UserId = deletedReview.UserId,
                MovieId = deletedReview.MovieId,
                ReviewText = deletedReview.ReviewText,
                Rating = deletedReview.Rating
            };
        }
        public async Task<IEnumerable<Review>> GetReviews(int userId)
        {
            return await _reviewRepository.GetAllReviews(userId);
        }
        private string GenerateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }
        private string GetHashedPassword(string password, string salt)
        {
            //never ever create your own Hashing Algorithms
            //always use Industry tried and tested Hashing Algorithms

            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                                     password: password,
                                                                     salt: Convert.FromBase64String(salt),
                                                                     prf: KeyDerivationPrf.HMACSHA512,
                                                                     iterationCount: 10000,
                                                                     numBytesRequested: 256 / 8));
            return hashed;

        }

        
    }
}
