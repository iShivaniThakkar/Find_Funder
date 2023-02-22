using FindFunder.Infra.Contract;
using FindFunder.Infra.Domain;
using FindFunder.Infra.Domain.Entities;
using FindFunder.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Infra.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly FindFunderContext _context;
        public CountryRepository(FindFunderContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Country>> GetCountries(string? searchTerm = null, int page = 1, int pageSize = 50)
        {
            try
            {
                var countries = _context.Countries.AsQueryable();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    countries = countries.Where(x =>
                    EF.Functions.Like(x.CountryName, $"%{searchTerm}%")
                   
                    );
                }

                var count = await countries.LongCountAsync();
                var pagedList = countries.ToPagedList(page, pageSize, count);

                return pagedList;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
