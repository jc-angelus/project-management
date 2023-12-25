
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
    /// Class: TasksServices
    /// </summary>
    public class TasksServices : ITasksServices
    {

        private readonly ITasksRepository _repositoryTasks;
        private readonly IMapper _mapper;

        public TasksServices(ITasksRepository repositoryTasks, IMapper mapper)
        {
            _repositoryTasks = repositoryTasks;
            _mapper = mapper;
        }

        public async Task<int> CreateTasksAsync(TasksModel TasksModel)
        {

            Tasks TasksEntity = _mapper.Map<Tasks>(TasksModel);

            TasksEntity = await _repositoryTasks.CreateAsync(TasksEntity);

            return TasksEntity.Id;
        }


        public async Task<TasksModel> ReadTasksAsync(int id)
        {

            Tasks TasksEntity = await _repositoryTasks.ReadAsync(id);

            TasksModel TasksEntityModel = _mapper.Map<TasksModel>(TasksEntity);

            return TasksEntityModel;

        }

        public async Task<TasksModel> UpdateTasksAsync(TasksModel TasksModel)
        {
            Tasks TasksEntity = _mapper.Map<Tasks>(TasksModel);

            TasksEntity = await _repositoryTasks.UpdateAsync(TasksEntity, TasksEntity.Id);

            TasksModel TasksEntityModel = _mapper.Map<TasksModel>(TasksEntity);

            return TasksEntityModel;
        }

        public async Task<bool> DeleteTasksAsync(int id)
        {
            return await _repositoryTasks.DeleteAsync(id);
        }

        public async Task<List<TasksModel>> TasksListAsync()
        {

            List<Tasks> TasksListEntities = (List<Tasks>)await _repositoryTasks.ListAsync();

            List<TasksModel> result = _mapper.Map<List<TasksModel>>(TasksListEntities);

            return result;

        }

    }
}
