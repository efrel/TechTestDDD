﻿using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;
using TechTestDDD.Api.Common.Errors;
using TechTestDDD.Api.Common.Mapping;

namespace TechTestDDD.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Api DDD {groupName}",
                    Version = groupName,
                    Description = "API de prueba técnica",
                    Contact = new OpenApiContact
                    {
                        Name = "Efrel López",
                        Email = "efli95.ealc@gmail.com",
                        Url = new Uri("https://github.com/efrel/TechTestDDD"),
                    }
                });
            });

            services.AddSingleton<ProblemDetailsFactory, TechTestDDDProblemDetailsFactory>();

            services.AddMappings();

            return services;
        }
    }
}
