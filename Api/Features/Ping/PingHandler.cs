using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Api.Features.Ping
{
    public class PingHandler : IRequestHandler<PingRequest, PingResponse>
    {
        private MySettings _mySettings;

        public PingHandler(MySettings mySettings)
        {
            _mySettings = mySettings;
        }
        
        public Task<PingResponse> Handle(PingRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new PingResponse
            {
                Ping = "pong"
            });
        }
    }
}