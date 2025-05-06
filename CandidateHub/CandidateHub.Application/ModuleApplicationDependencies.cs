using CandidateHub.Application.Abstracts;
using CandidateHub.Application.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace CandidateHub.Application
{
    public static class ModuleApplicationDependencies
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICandidateService, CandidateService>();
            return services;
        }
    }
}
