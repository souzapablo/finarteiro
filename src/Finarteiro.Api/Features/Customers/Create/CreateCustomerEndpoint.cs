using Finarteiro.Api.Common.Base;
using Finarteiro.Api.Extensions;
using FluentValidation;
using MediatR;

namespace Finarteiro.Api.Features.Customers.Create;

public class CreateCustomerEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("", HandleAsync);

    public static async Task<IResult> HandleAsync(
        ISender sender,
        CreateCustomerCommand command,
        IValidator<CreateCustomerCommand> validator)
    {
        var result = await sender.Send(command);

        return result.IsSuccess ?
            TypedResults.Created($"api/v1/customers/{result.Data}", result) :
            result.HandleFailure();
    }
}
