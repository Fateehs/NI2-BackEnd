using NI2_API.Application.Abstractions.Services.Authentications;

namespace NI2_API.Application.Abstractions.Services
{
    public interface IAuthService : IExternalAuthentication, IInternalAuthentication
    {
    }
}
