# API with Mediatr & FluentValidation (and typed appsettings & Swagger)
1. Request comes in to controller
2. Request is sent to mediator pipeline
3. Validationbehavior picks up the request and validates
4. If request is valid then handler picks up the request and handles it, controller returns bad request otherwise
5. Response is sent back to method in BaseController
6. Check if response is not null, 404 not found if null and 200 ok if not null

## Nugets
* FluentValidation
* FluentValidation.AspNetCore
* MediatR
* MediatR.Extensions.Microsoft.DependencyInjection