using FindFunder.Infra.Contract;
using FindFunder.Infra.Domain.Entities;
using FindFunder.Infra.Domain;
using FindFunder.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Infra.Repository
{
    public class CityRepository:ICityRepository
    {
        private readonly FindFunderContext _context;

        public CityRepository(FindFunderContext context)
        {
            _context = context;
        }


        public async Task<PagedList<City>> GetCities(string? searchTerm, int page, int pageSize)
        {
            try
            {
                var cities = _context.Cities.Include(x => x.State).AsQueryable();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    cities = cities.Where(x =>
                    EF.Functions.Like(x.CityName, $"%{searchTerm}%") ||
                    EF.Functions.Like(x.State.StateName, $"%{searchTerm}%")

                    );
                }

                var count = await cities.LongCountAsync();
                var pagedList = cities.ToPagedList(page, pageSize, count);

                return pagedList;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
