using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N5.Permissions.DAL.Context;
using N5.Permissions.DAL.Interfaces;

namespace N5.Permissions.DAL.Configurations;
public static class DependencyServices
{
    public static IServiceCollection AddDataDependencyServices(this IServiceCollection services)
    {
        services.AddTransient<IPermissionRepository, PermissionRepository>();
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PermissionsContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}
