using ProjectManagementDomain.Models;

namespace ProjectManagementApplication.Interfaces
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Interface: ITasksServices
    /// </summary>
    public interface IStatesServices
    {
        
        Task<List<StatesModel>> StatesListAsync();
    }
}