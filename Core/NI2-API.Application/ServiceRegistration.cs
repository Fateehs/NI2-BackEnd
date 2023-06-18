using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using NI2_API.Application.Abstractions.Services;

namespace NI2_API.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
