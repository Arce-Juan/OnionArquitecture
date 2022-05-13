using Application.DTOs;
using Application.Wrappers;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Clients.Queries.GetAllClients
{
    public class GetAllClientsQuery : IRequest<Response<List<ClientDto>>>
    {

    }
}
