
using AutoMapper;
using ProjectManagementApplication.Interfaces;
using ProjectManagementDomain.Models;
using ProjectManagementInfrastructure.Entities;
using ProjectManagementInfrastructure.Repositories.Interfaces.Entities;

namespace ProjectManagementApplication.Services
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 09/02/2023
    /// Class: ProjectsServices
    /// </summary>
    public class ProjectsServices : IProjectsServices
    {

        private readonly IProjectsRepository _repositoryProjects;
        private readonly IMapper _mapper;

        public ProjectsServices(IProjectsRepository repositoryProjects, IMapper mapper)
        {
            _repositoryProjects = repositoryProjects;
            _mapper = mapper;
        }

        public async Task<int> CreateProjectsAsync(ProjectsModel ProjectsModel)
        {

            Projects ProjectsEntity = _mapper.Map<Projects>(ProjectsModel);

            ProjectsEntity = await _repositoryProjects.CreateAsync(ProjectsEntity);

            return ProjectsEntity.Id;
        }


        public async Task<ProjectsModel> ReadProjectsAsync(int id)
        {

            Projects ProjectsEntity = await _repositoryProjects.ReadAsync(id);

            ProjectsModel ProjectsEntityModel = _mapper.Map<ProjectsModel>(ProjectsEntity);

            return ProjectsEntityModel;

        }

        public async Task<ProjectsModel> UpdateProjectsAsync(ProjectsModel ProjectsModel)
        {
            Projects ProjectsEntity = _mapper.Map<Projects>(ProjectsModel);

            ProjectsEntity = await _repositoryProjects.UpdateAsync(ProjectsEntity, ProjectsEntity.Id);

            ProjectsModel ProjectsEntityModel = _mapper.Map<ProjectsModel>(ProjectsEntity);

            return ProjectsEntityModel;
        }

        public async Task<bool> DeleteProjectsAsync(int id)
        {
            return await _repositoryProjects.DeleteAsync(id);
        }

        public async Task<List<ProjectsModel>> ProjectsListAsync()
        {

            List<Projects> ProjectsListEntities = (List<Projects>)await _repositoryProjects.ListAsync();

            List<ProjectsModel> result = _mapper.Map<List<ProjectsModel>>(ProjectsListEntities);

            return result;

        }

    }
}
