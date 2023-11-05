﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        var assembly = typeof(DependencyInjection).Assembly;
  
        services.AddAutoMapper(assembly);
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(assembly));
        //Todo Exception Handler

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
