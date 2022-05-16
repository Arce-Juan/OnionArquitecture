using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using Application.Specifications;

namespace Application.Features.Clients.Queries.GetAllClients
{
    //public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, Response<List<ClientDto>>>
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, PagedResponse<List<ClientDto>>>
    {
        private readonly IRepositoryAsync<Client> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllClientsQueryHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<ClientDto>>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var spec = new PagedClientsSpecifications(request.PageNumber, request.PageSize, request.FilterByLastName, request.FilterByName);

            var colecction = await _repositoryAsync.ListAsync(spec, cancellationToken);
            var listClientDto = _mapper.Map<List<ClientDto>>(colecction);

            return new PagedResponse<List<ClientDto>>(listClientDto, request.PageNumber, request.PageSize);
        }

        /*
        public async Task<Response<List<ClientDto>>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var colecction = await _repositoryAsync.ListAsync(cancellationToken);
            var listClientDto = _mapper.Map<List<ClientDto>>(colecction);

            return new Response<List<ClientDto>>(listClientDto);
        }
        */
    }
}
