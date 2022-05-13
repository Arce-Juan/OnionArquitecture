﻿using Application.Features.Clients.Commands.CreateClientCommand;
using Application.Features.Clients.Commands.DeleteClientCommand;
using Application.Features.Clients.Commands.UpdateClientCommand;
using Application.Features.Clients.Queries.GetClientById;
using Application.Features.Clients.Queries.GetAllClients;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetClientByIdQuery() { Id = id }));
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] GetAllClientsParameters filters)
        {
            return Ok(await Mediator.Send(new GetAllClientsQuery()
            {
                FilterByLastName = filters.FilterByLastName,
                FilterByName = filters.FilterByName,
                PageNumber = filters.PageNumber,
                PageSize = filters.PageSize
            }));
        }

        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateClientCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //POST api/<controller>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateClientCommand command)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command));
        }

        //POST api/<controller>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteClientCommand() { Id = id}));
        }

        
    }
}
