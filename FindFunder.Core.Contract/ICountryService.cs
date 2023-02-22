using FindFunder.Infra.Domain.Entities;
using FindFunder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Core.Contract
{
    public interface ICountryService
    {
        Task<PagedList<Country>> GetCountryAsync(string searchTerm = null, int page = 1, int pageSize = 25);
    }
}
