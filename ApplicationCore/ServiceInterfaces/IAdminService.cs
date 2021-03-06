using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IAdminService
    {
        Task<MovieCreateResponseModel> CreateMovie(MovieCreateRequestModel model);
        Task<MovieCreateResponseModel> UpdateMovie(MovieCreateRequestModel model);
        Task<IEnumerable<Purchase>> GetAllPurchases();
    }
}
