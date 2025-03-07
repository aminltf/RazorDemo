﻿#nullable disable

using Application.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DepartmentProfile));
        services.AddAutoMapper(typeof(EmployeeProfile));

        return services;
    }
}
