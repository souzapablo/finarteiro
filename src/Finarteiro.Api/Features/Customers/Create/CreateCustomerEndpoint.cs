using Finarteiro.Api.Common.Base;
using Finarteiro.Api.Common.Result;
using Finarteiro.Api.Extensions;
using FluentValidation;
using MediatR;

namespace Finarteiro.Api.Features.Customers.Create;

public class CreateCustomerEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("", HandleAsync)
            .WithName("Create customer")
            .WithDescription("Create a new customer in the application")
            .Produces<Result<Guid>>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status422UnprocessableEntity)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

    public static async Task<IResult> HandleAsync(
        ISender sender,
        CreateCustomerCommand command)
    {
        var result = await sender.Send(command);

        return result.IsSuccess ?
            TypedResults.Created($"api/v1/customers/{result.Data}", result) :
            result.HandleFailure();
    }
}
