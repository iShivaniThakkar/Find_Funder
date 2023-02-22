using FindFunder.Infra.Domain.Entities;
using FindFunder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Infra.Contract
{
    public interface ICityRepository
    {
        Task<PagedList<City>> GetCities(string? searchTerm = null, int page = 1, int pageSize = 100);
    }
}
