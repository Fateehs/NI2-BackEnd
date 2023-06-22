using NI2_API.Domain.Entities.Identity;

namespace NI2_API.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int second, AppUser appUser);
    }
}
