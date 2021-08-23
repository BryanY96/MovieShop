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
    }
}
