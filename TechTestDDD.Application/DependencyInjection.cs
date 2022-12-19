using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace TechTestDDD.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
