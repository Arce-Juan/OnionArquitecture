using Application.DTOs.Users;
using Application.Wrappers;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponseDto>> AuthenticateAsync(AuthenticationRequestDto request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequestDto request, string origin);
    }
}
