using System.Threading.Tasks;
using Api.Features.Ping;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("ping")]
    public class PingController : BaseController
    {
        public PingController(IMediator mediator) : base(mediator)
        { }
        
        [HttpPost]
        public async Task<IActionResult> Post(PingHandler.PingRequest request)
        {
            return await HandleRequestAsync<PingHandler.PingRequest, PingHandler.PingResponse>(request);
        }
    }
}