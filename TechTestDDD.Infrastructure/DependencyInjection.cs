using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechTestDDD.Application.Common.Interfaces.Authentication;
using TechTestDDD.Application.Common.Interfaces.Persistence;
using TechTestDDD.Application.Common.Interfaces.Services;
using TechTestDDD.Infrastructure.Authentication;
using TechTestDDD.Infrastructure.Persistence;
using TechTestDDD.Infrastructure.Services;

namespace TechTestDDD.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
