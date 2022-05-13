using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clients.Commands.UpdateClientCommand
{
    public class UpdateClientCommand
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
