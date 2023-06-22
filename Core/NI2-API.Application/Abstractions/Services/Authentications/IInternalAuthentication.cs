using NI2_API.Application.DTOs;

namespace NI2_API.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<Application.DTOs.Token> LoginAsync(string username,string password, int accessTokenLifeTime);
    }
}
