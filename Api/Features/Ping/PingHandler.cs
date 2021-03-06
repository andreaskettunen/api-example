using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Api.Features.Ping
{
    public class PingHandler : IRequestHandler<PingHandler.PingRequest, PingHandler.PingResponse>
    {
        private MySettings _mySettings;

        public PingHandler(MySettings mySettings)
        {
            _mySettings = mySettings;
        }
        
        public Task<PingResponse> Handle(PingRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                new PingResponse
                {
                    Ping = "pong"
                });
        }

        public record PingRequest() : IRequest<PingResponse>
        {
            public int ToValidate { get; init; }
        }

        public record PingResponse()
        {
            public string Ping { get; init; }
        }
    }
    
    public class PingValidator : AbstractValidator<PingHandler.PingRequest>
    {
        public PingValidator()
        {
            RuleFor(r => r.ToValidate).NotEmpty();
        }
    }
}