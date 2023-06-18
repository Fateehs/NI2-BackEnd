using MediatR;

namespace NI2_API.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string Username { get; set; }
        public string SteamId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}