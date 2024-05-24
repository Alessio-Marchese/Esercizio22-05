using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Shared;
    public static class Services
    {
        public static IServiceCollection AddMyLibraryServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
