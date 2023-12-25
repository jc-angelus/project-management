
using ProjectManagementInfrastructure.Entities;
using ProjectManagementInfrastructure.Repositories.Generic;
using ProjectManagementInfrastructure.Repositories.Interfaces.Entities;
using ProjectManagementInfrastructure.Repositories.Interfaces.Generic;

namespace ProjectManagementInfrastructure.Repositories.Entities
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: TasksRepository
    /// </summary>
    public class TasksRepository : GenericRepository<Tasks>, ITasksRepository
    {
        public TasksRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
