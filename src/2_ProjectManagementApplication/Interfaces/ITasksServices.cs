using ProjectManagementDomain.Models;

namespace ProjectManagementApplication.Interfaces
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Interface: ITasksServices
    /// </summary>
    public interface ITasksServices
    {
        Task<int> CreateTasksAsync(TasksModel TasksModel);
        Task<TasksModel> ReadTasksAsync(int id);        
        Task<TasksModel> UpdateTasksAsync(TasksModel TasksModel);
        Task<bool> DeleteTasksAsync(int id);
        Task<List<TasksModel>> TasksListAsync();
    }
}