using Microsoft.AspNetCore.Identity;
using NI2_API.Application.Abstractions.Services;
using NI2_API.Application.Abstractions.Token;
using NI2_API.Application.DTOs;
using NI2_API.Application.DTOs.User;
using NI2_API.Domain.Entities.Identity;

namespace NI2_API.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<Token> LoginAsync(string username, string password, int accessTokenLifeTime)
        {
            Domain.Entities.Identity.AppUser? user = await _userManager.FindByNameAsync(username);
            if (user == null)
                user = await _userManager.FindByNameAsync(username);

            if (user == null)
                throw new Exception("Kullanıcı bulunamadı hatası");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);

                return token;
            }

            throw new Exception("Yetkilendirme hatası");
        }
    }
}
