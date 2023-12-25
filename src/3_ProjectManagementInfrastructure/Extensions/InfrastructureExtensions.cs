using ProjectManagementInfrastructure.Context;
using ProjectManagementInfrastructure.Repositories.Entities;
using ProjectManagementInfrastructure.Repositories.Generic;
using ProjectManagementInfrastructure.Repositories.Interfaces.Entities;
using ProjectManagementInfrastructure.Repositories.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectManagementInfrastructure.Extensions
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: InfrastructureExtensions
    /// </summary>
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();            
            services.AddScoped<IUnitOfWork, UnitOfWork>();            
            services.AddScoped<IProjectsRepository, ProjectsRepository>();
            services.AddScoped<ITasksRepository, TasksRepository>();
            services.AddScoped<IStatesRepository, StatesRepository>();
            services.AddDbContext<ProjectManagementDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:ProjectsDb"]));

            return services;
        }

    }
}
