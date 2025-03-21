using Finarteiro.Api.Common.Base;
using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;

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
        var validationResult = await validator.ValidateAsync(command);

        if (!validationResult.IsValid)
            return TypedResults.UnprocessableEntity(validationResult.Errors);

        var result = await sender.Send(command);

        return result.IsSuccess ?
            TypedResults.Created($"api/v1/customers/{result.Data}", result) :
            TypedResults.BadRequest(result.Error);
    }
}
