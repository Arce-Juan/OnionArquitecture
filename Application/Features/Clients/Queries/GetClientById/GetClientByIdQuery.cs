using Application.DTOs;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQuery : IRequest<Response<ClientDto>> // La respuesta de este query es el ClientDto
    {
        public int Id { get; set; }
    }
}
