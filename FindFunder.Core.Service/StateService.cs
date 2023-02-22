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
    public class StateService:IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;

        public StateService(IStateRepository stateRepository, IMapper mapper) 
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }


        public async Task<PagedList<State>> GetStatesAsync(string searchTerm = null, int page = 1, int pageSize = 25)
        {
            try
            {
                var states = await _stateRepository.GetStates(searchTerm, page, pageSize);
                var result = _mapper.Map<PagedList<State>>(states);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
