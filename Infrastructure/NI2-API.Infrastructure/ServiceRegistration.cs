using Microsoft.Extensions.DependencyInjection;
using NI2_API.Application.Abstractions.Token;
using NI2_API.Infrastructure.Services.Token;

namespace NI2_API.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
