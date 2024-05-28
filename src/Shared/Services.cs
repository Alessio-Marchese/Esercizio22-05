using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Shared;
public static class SharedServicesExtensions
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
