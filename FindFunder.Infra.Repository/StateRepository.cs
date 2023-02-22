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
    public class StateRepository : IStateRepository
    {
        private readonly FindFunderContext _context;

        public StateRepository(FindFunderContext context)
        {
            _context = context;
        }


        public async Task<PagedList<State>> GetStates(string? searchTerm, int page, int pageSize)
        {
            try
            {
                var states = _context.States.Include(x => x.Country).AsQueryable();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    states = states.Where(x =>
                    EF.Functions.Like(x.StateName, $"%{searchTerm}%") ||
                    EF.Functions.Like(x.Country.CountryName, $"%{searchTerm}%")

                    );
                }

                var count = await states.LongCountAsync();
                var pagedList = states.ToPagedList(page, pageSize, count);

                return pagedList;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
    }
}
