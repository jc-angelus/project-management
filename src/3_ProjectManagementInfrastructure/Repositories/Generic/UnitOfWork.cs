using ProjectManagementInfrastructure.Context;
using ProjectManagementInfrastructure.Repositories.Interfaces.Generic;

namespace ProjectManagementInfrastructure.Repositories.Generic
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 09/02/2023
    /// Class: UnitOfWork
    /// </summary
    public class UnitOfWork : IUnitOfWork
    {
        public ProjectManagementDbContext Context { get; }

        public UnitOfWork(ProjectManagementDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
