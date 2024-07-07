using PracticaConeccionHR.Context;
using PracticaConeccionHR.Repository;

namespace PracticaConeccionHR.Extensions.DependencyInjection
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection addMyDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IHRMDBContext, HRMDBContext>();
            services.AddScoped<IJobsRepository, JobsRepository>();
             
            return services;
        }
    }
}
