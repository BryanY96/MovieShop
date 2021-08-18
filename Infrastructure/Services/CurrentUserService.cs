using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}

        public int UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsAuthenticated => throw new NotImplementedException();

        public string Email => throw new NotImplementedException();

        public string FullName => throw new NotImplementedException();

        public bool IsAdmin => throw new NotImplementedException();

        public bool IsSuperAdmin => throw new NotImplementedException();

        public IEnumerable<string> Roles => throw new NotImplementedException();
    }
}
