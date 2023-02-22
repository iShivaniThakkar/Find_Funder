using AutoMapper;
using FindFunder.Core.Contract;
using FindFunder.Infra.Contract;
using FindFunder.Infra.Domain.Entities;
using FindFunder.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Core.Service
{
    public class CountryService : ICountryService

    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<PagedList<Country>> GetCountryAsync(string searchTerm = null, int page = 1, int pageSize = 25)
        {
            try
            {
                var country = await _countryRepository.GetCountries(searchTerm, page, pageSize);
                var result = _mapper.Map<PagedList<Country>>(country);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
