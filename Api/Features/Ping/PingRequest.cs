using FluentValidation;
using MediatR;

namespace Api.Features.Ping
{
    public class PingRequest : IRequest<PingResponse>
    {
        public int ToValidate { get; set; }
    }
    
    public class PingValidator : AbstractValidator<PingRequest>
    {
        public PingValidator()
        {
            RuleFor(r => r.ToValidate).NotEmpty();
        }
    }
}