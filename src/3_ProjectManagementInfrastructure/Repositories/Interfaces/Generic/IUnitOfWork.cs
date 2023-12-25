using ProjectManagementInfrastructure.Context;

namespace ProjectManagementInfrastructure.Repositories.Interfaces.Generic
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Interface: IUnitOfWork
    /// </summary
    public interface IUnitOfWork : IDisposable
    {
        ProjectManagementDbContext Context { get; }
        void Commit();
    }
}
