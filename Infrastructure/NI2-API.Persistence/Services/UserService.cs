using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NI2_API.Application.Abstractions.Services;
using NI2_API.Application.DTOs;
using NI2_API.Domain.Entities.Identity;

namespace NI2_API.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username
            }, model.Password);

            CreateUserResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Account successfully created!";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }

        public async Task<List<ListUser>> GetAllUsersAsync(int page, int size)
        {
            var users = await _userManager.Users
                  .Skip(page * size)
                  .Take(size)
                  .ToListAsync();

            return users.Select(user => new ListUser
            {
                Id = user.Id,
                SteamId = user.Id,   

            }).ToList();
        }

        public int TotalUsersCount => _userManager.Users.Count();
    }
}
