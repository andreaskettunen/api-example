using System;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator { get; }

        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
        
        protected async Task<IActionResult> HandleRequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : class
        {
            if (request is null)
            {
                return BadRequest();
            }

            try
            {
                var response = await Mediator.Send(request);

                if (response is null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (ValidationException validationException)
            {
                foreach (var error in validationException.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}