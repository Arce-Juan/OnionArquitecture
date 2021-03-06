using Application.DTOs.Users;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Authtenticate.Commands.AuthenticateCommand
{
    public class AuthenticateCommand : IRequest<Response<AuthenticationResponseDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
    }
}
