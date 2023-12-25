using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ProjectManagementDomain.Mappers;
using ProjectManagementInfrastructure.Extensions;
using ProjectManagementApplication.Interfaces;
using ProjectManagementApplication.Services;

namespace ProjectManagementApplication.Extensions
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: ApplicationExtensions
    /// </summary>
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();            
            services.AddAutoMapper(typeof(DomainMappingProfile));
            services.AddMediatR(Assembly.GetExecutingAssembly());            
            services.AddScoped<IProjectsServices, ProjectsServices>();
            services.AddScoped<ITasksServices, TasksServices>();
            services.AddScoped<IStatesServices, StatesServices>();
            services.AddScoped<ILoginServices, LoginServices>();
            InfrastructureExtensions.AddInfrastructure(services, configuration);            
            return services;
        }

    }
}
