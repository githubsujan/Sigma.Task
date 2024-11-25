using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Sigma.Task.Application
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
