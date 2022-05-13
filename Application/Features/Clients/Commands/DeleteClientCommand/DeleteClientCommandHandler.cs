using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Clients.Commands.DeleteClientCommand
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Client> _repositoryAsync;

        public DeleteClientCommandHandler(IRepositoryAsync<Client> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _repositoryAsync.GetByIdAsync(request.Id);
            if (client == null)
                throw new KeyNotFoundException($"El registro con ID: {request.Id} no fue encontrado.");

            await _repositoryAsync.DeleteAsync(client);

            return new Response<int>(client.Id);
        }
    }
}
