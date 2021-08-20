﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IGenreRepository: IAsyncRepository<Genre>
    {
        Task<Genre> GetMoviesByGenreId(int id);
    }
}
