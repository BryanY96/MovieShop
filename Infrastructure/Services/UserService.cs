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
        public UserService(IUserRepository userRepository, ICurrentUserService currentUserService, 
            IMovieRepository movieRepository, IPurchaseRepository purchaseRepository, IFavoriteRepository favoriteRepository)
        {
            _userRepository = userRepository;
            _currentUserService = currentUserService;
            _movieRepository = movieRepository;
            _purchaseRepository = purchaseRepository;
            _favoriteRepository = favoriteRepository;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetFavoriteMovies(int userId)
        {
            var user = await _userRepository.GetUserFavoriteById(userId);
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in user.Favorites)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
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

        public async Task<UserResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            var userResponseModel = new UserResponseModel()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth
            };
            return userResponseModel;
        }

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

        public async Task<MovieCardResponseModel> BuyMovie(int movieId)
        {
            var purchasedMovie = await _userRepository.GetPurchasedMovieById(movieId, _currentUserService.UserId);
            if (purchasedMovie != null)
            {
                throw new ConflictException("You already bought this movie before");
            }
            var movie = await _movieRepository.GetByIdAsync(movieId);
            var purchaseMovie = new Purchase
            {
                UserId = _currentUserService.UserId,
                MovieId = movie.Id,
                TotalPrice = movie.Price.GetValueOrDefault(),
                PurchaseDateTime = DateTime.Now
            };
            var createdPurchase = await _purchaseRepository.AddAsync(purchaseMovie);
            return new MovieCardResponseModel
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl
            };

        }

        public async Task<string> AddToFavorite(int movieId)
        {
            var dbFavorite = await _favoriteRepository.GetExistAsync(f => f.MovieId == movieId && f.UserId == _currentUserService.UserId);
            if (dbFavorite != true)
            {
                return "Conflict";
            }
            await _favoriteRepository.AddAsync(new Favorite
            {
                UserId = _currentUserService.UserId,
                MovieId = movieId
            });
            return "Added";
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
