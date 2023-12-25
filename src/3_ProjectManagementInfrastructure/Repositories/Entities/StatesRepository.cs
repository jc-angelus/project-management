
using ProjectManagementInfrastructure.Entities;
using ProjectManagementInfrastructure.Repositories.Generic;
using ProjectManagementInfrastructure.Repositories.Interfaces.Entities;
using ProjectManagementInfrastructure.Repositories.Interfaces.Generic;

namespace ProjectManagementInfrastructure.Repositories.Entities
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: StatesRepository
    /// </summary>
    public class StatesRepository : GenericRepository<States>, IStatesRepository
    {
        public StatesRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
