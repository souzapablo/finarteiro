using Finarteiro.Api.Common.Base;
using Finarteiro.Api.Common.Result;
using Microsoft.AspNetCore.Mvc;

namespace Finarteiro.Api.Extensions;
public static class ResultExtensions
{
    public static IResult HandleFailure(this Result result) =>
        result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException(),
            IValidationResult validationResult => TypedResults.BadRequest(
                CreateProblemDetails(
                    "Validation Error",
                    StatusCodes.Status422UnprocessableEntity,
                    result.Error!,
                    validationResult.Errors
                )),
            _ => TypedResults.BadRequest(CreateProblemDetails(
                "Bad Request",
                StatusCodes.Status400BadRequest,
                result.Error!
                ))
        };


    private static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        Error[]? errors = null) =>
        new()
        {
            Title = title,
            Type = error.Code,
            Detail = error.Message,
            Status = status,
            Extensions = { { nameof(errors), errors } }
        };
}