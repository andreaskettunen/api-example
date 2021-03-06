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
            return Task.FromResult(new PingResponse("pong"));
        }

        public record PingRequest(int ToValidate) : IRequest<PingResponse>;
        public record PingResponse(string Ping);
        
        public class PingValidator : AbstractValidator<PingRequest>
        {
            public PingValidator()
            {
                RuleFor(r => r.ToValidate).NotEmpty();
            }
        }
    }
}