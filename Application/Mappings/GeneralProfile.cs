using Application.DTOs;
using Application.Features.Clients.Commands.CreateClientCommand;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Client, ClientDto>();
            CreateMap<List<Client>, List<ClientDto>>();
            #endregion

            #region Commands
            CreateMap<CreateClientCommand, Client>();
            #endregion
        }
    }
}
