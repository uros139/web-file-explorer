﻿using WebFileExplorer.Api.Infrastructure;
using WebFileExplorer.Api.Infrastructure.ExceptionHandling;

namespace WebFileExplorer.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
            });
        });

        services.AddSwaggerGen();

        services.AddControllers();

        services.Scan(scan => scan
            .FromAssemblyOf<IExceptionHandlerStrategy>()
            .AddClasses(classes => classes.AssignableTo<IExceptionHandlerStrategy>())
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        services.AddExceptionHandler<GlobalExceptionHandler>();

        services.AddProblemDetails();

        return services;
    }
}
