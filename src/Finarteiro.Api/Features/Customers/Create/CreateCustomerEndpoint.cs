using Finarteiro.Api.Common.Base;
using MediatR;

namespace Finarteiro.Api.Features.Customers.Create;

public class CreateCustomerEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("", HandleAsync);

    public static async Task<IResult> HandleAsync(
        ISender sender,
        CreateCustomerInput input)
    {
        var command = input.ToCommand();
        var result = await sender.Send(command);

        return TypedResults.Created($"api/v1/customers/{result}", result);
    }
}
