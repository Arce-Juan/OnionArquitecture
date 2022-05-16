using Application.DTOs;
using Application.Wrappers;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Clients.Queries.GetAllClients
{
    //public class GetAllClientsQuery : IRequest<Response<List<ClientDto>>>
    public class GetAllClientsQuery : IRequest<PagedResponse<List<ClientDto>>>
    {
        public string FilterByLastName { get; set; }
        public string FilterByName { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
