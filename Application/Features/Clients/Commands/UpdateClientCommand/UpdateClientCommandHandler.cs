using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Clients.Commands.UpdateClientCommand
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Client> _repositoryAsync;

        public UpdateClientCommandHandler(IRepositoryAsync<Client> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _repositoryAsync.GetByIdAsync(request.Id);
            if (client == null)
                throw new KeyNotFoundException($"El registro con ID: {request.Id} no fue encontrado.");

            client.LastName = request.LastName;
            client.Name = request.Name;
            client.DateBirth = request.DateBirth;
            client.PhoneNumber = request.PhoneNumber;
            client.Email = request.Email;
            client.Address = request.Address;

            await _repositoryAsync.UpdateAsync(client);

            return new Response<int>(client.Id);
        }
    }
}
