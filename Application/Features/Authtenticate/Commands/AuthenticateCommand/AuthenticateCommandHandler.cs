using Application.DTOs.Users;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Authtenticate.Commands.AuthenticateCommand
{
    public class AuthenticateCommandHandler: IRequestHandler<AuthenticateCommand, Response<AuthenticationResponseDto>>
    {
        private readonly IAccountService _accountService;

        public AuthenticateCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Response<AuthenticationResponseDto>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.AuthenticateAsync(new AuthenticationRequestDto
            {
                Email = request.Email,
                Password = request.Password
            }, request.IpAddress);
        }
    }
}
