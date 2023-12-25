using AutoMapper;
using ProjectManagementDomain.Models;
using ProjectManagementInfrastructure.Entities;

namespace ProjectManagementDomain.Mappers
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: DomainMappingProfile
    /// </summary
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {            

            CreateMap<ProjectsModel, Projects>()
            .ForMember(x => x.Tasks, x => x.MapFrom(y => y.TasksModel))
            .ForMember(x => x.States, x => x.MapFrom(y => y.StatesModel))
            .ReverseMap();
            
            CreateMap<TasksModel, Tasks>()
            .ForMember(x => x.States, x => x.MapFrom(y => y.StatesModel))
            .ReverseMap();

            CreateMap<StatesModel, States>().ReverseMap();
        }
    }
}
