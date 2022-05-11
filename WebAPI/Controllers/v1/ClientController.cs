using Application.Features.Clients.Commands.CreateClientCommand;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    /*
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
    }
    */
    [ApiVersion("1.0")]
    public class ClientController : BaseApiController
    {
        //POST
        [HttpPost]
        public async Task<IActionResult> Post(CreateClientCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
