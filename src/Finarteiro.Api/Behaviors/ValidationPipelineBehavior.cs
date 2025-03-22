using Finarteiro.Api.Common.Base;
using Finarteiro.Api.Common.Result;
using FluentValidation;
using MediatR;

namespace Finarteiro.Api.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any())
            return await next();

        Error[] errors = [.. validators
            .Select(x => x.Validate(request))
            .SelectMany(x => x.Errors)
            .Where(validationFailure => validationFailure is not null)
            .Select(failure => new Error(failure.PropertyName, failure.ErrorMessage))
            .Distinct()];

        if (errors.Length != 0)
            return CreateValidationResult<TResponse>(errors);

        return await next();
    }

    private static TResult CreateValidationResult<TResult>(Error[] errors)
        where TResult : Result
    {
        if (typeof(TResult) == typeof(Result))
            return (ValidationResult.WithErrrors(errors) as TResult)!;

        object validationResult = typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GetGenericArguments()[0])
            .GetMethod(nameof(ValidationResult.WithErrrors))!
            .Invoke(null, [errors])!;

        return (TResult)validationResult;
    }
}
