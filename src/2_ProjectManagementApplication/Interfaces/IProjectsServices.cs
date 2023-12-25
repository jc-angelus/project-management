using ProjectManagementDomain.Models;

namespace ProjectManagementApplication.Interfaces
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Interface: IProjectsServices
    /// </summary>
    public interface IProjectsServices
    {
        Task<int> CreateProjectsAsync(ProjectsModel ProjectsModel);
        Task<ProjectsModel> ReadProjectsAsync(int id);        
        Task<ProjectsModel> UpdateProjectsAsync(ProjectsModel ProjectsModel);
        Task<bool> DeleteProjectsAsync(int id);
        Task<List<ProjectsModel>> ProjectsListAsync();
    }
}