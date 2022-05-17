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
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using Newtonsoft.Json;
using System;

namespace Application.Features.Clients.Queries.GetAllClients
{
    //public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, Response<List<ClientDto>>>
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, PagedResponse<List<ClientDto>>>
    {
        private readonly IRepositoryAsync<Client> _repositoryAsync;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public GetAllClientsQueryHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper, IDistributedCache distributedCache)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<PagedResponse<List<ClientDto>>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var listClients = new List<Client>();

            var cacheKey = $"ClientsList_{request.PageSize}_{request.PageNumber}_{request.FilterByLastName}_{request.FilterByName}";
            string seralizedClientsList;
            var redisClientsList = await _distributedCache.GetAsync(cacheKey);

            if (redisClientsList != null)
            {
                //obtenemos de Redis los datos
                seralizedClientsList = Encoding.UTF8.GetString(redisClientsList);
                listClients = JsonConvert.DeserializeObject<List<Client>>(seralizedClientsList);
            }
            else
            {
                var spec = new PagedClientsSpecifications(request.PageNumber, request.PageSize, request.FilterByLastName, request.FilterByName);
                listClients = await _repositoryAsync.ListAsync(spec, cancellationToken);

                //alojamos a de Redis los datos
                seralizedClientsList = JsonConvert.SerializeObject(listClients);
                redisClientsList = Encoding.UTF8.GetBytes(seralizedClientsList);

                var option = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10)) // Dura 10 min memoria desde que se agrego
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2)); // cadicudad de 2 min si no esta utilizando

                await _distributedCache.SetAsync(cacheKey, redisClientsList, option);
            }

            var listClientDto = _mapper.Map<List<ClientDto>>(listClients);
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
