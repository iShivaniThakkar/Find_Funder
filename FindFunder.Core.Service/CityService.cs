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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<City>> GetCitiesAsync(string searchTerm = null, int page = 1, int pageSize = 25)
        {
            try
            {
                var cities = await _cityRepository.GetCities(searchTerm, page, pageSize);
                var result = _mapper.Map<PagedList<City>>(cities);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
