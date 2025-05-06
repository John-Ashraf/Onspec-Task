using CandidateHub.Infrastructure.Implementation;
using CandidateHub.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CandidateHub.Infrastructure
{
    public static class ModuleInfrasStructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepoAsync<>), typeof(GenericRepoAsync<>));
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            return services;
        }

    }
}
