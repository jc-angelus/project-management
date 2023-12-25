
using AutoMapper;
using ProjectManagementDomain.Models;
using ProjectManagementApplication.Interfaces;
using ProjectManagementInfrastructure.Entities;
using ProjectManagementInfrastructure.Repositories.Interfaces.Entities;

namespace ProjectManagementApplication.Services
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: StatesServices
    /// </summary>
    public class StatesServices : IStatesServices
    {

        private readonly IStatesRepository _repositoryStates;
        private readonly IMapper _mapper;

        public StatesServices(IStatesRepository repositoryStates, IMapper mapper)
        {
            _repositoryStates = repositoryStates;
            _mapper = mapper;
        }
        
        public async Task<List<StatesModel>> StatesListAsync()
        {

            List<States> StatesListEntities = (List<States>)await _repositoryStates.ListAsync();

            List<StatesModel> result = _mapper.Map<List<StatesModel>>(StatesListEntities);

            return result;

        }

    }
}
