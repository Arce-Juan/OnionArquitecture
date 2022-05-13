using Application.Parameters;

namespace Application.Features.Clients.Queries.GetAllClients
{
    public class GetAllClientsParameters : RequestParameter
    {
        public string FilterByLastName { get; set; }
        public string FilterByName { get; set; }
    }
}
