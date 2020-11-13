using EducationManagement.Services.Implementations;
using EducationManagement.Services.Interfaces;
using EducatoinManagement.DataAccessLayer.Contracts;
using EducatoinManagement.DataAccessLayer.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EducatoinManagement.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IStudentsService, StudentsService>();
            services.AddTransient<IRegionsService, RegionsService>();
            services.AddTransient<IStudentsRepository, StudentsRepository>();
            services.AddTransient<IClassesRepository, ClassesRepository>();
            services.AddTransient<IClassesService, ClassesService>();
            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<ISchoolsService, SchoolsService>();
            services.AddTransient<IRegionsRepository, RegionsRepository>();
            //todo register services
        }
    }
}
