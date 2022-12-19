using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Runtime.CompilerServices;

namespace TechTestDDD.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}
