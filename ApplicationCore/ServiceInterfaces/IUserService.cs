using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel model);

        Task<UserLoginResponseModel> Login(LoginRequestModel model);

        Task<IEnumerable<MovieCardResponseModel>> GetPuchasedMovies(int userId);
        Task<IEnumerable<MovieCardResponseModel>> GetFavoriteMovies(int userId);
       
        Task<IEnumerable<UserResponseModel>> GetAllUsers();
        Task<PurchaseResponseModel> BuyMovie(PurchaseRequestModel model);
        Task<FavoriteResponseModel> AddToFavorite(FavoriteRequestModel model);
        Task<UnfavoriteModel> RemoveFromFavorite(UnfavoriteModel model);
        Task<ReviewResponseModel> WriteReview(ReviewRequestModel model);
        Task<ReviewResponseModel> UpdateReview(ReviewRequestModel model);
        Task<ReviewResponseModel> DeleteReview(int userId, int movieId);
        Task<IEnumerable<Review>> GetReviews(int userId);
        //Task RemoveFromFavorite(FavoriteRequestModel model);
        Task<bool> IsFavoriteExists(int id, int movieId);
    }
}
