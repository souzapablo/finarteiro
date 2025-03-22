using Finarteiro.Api.Common.Base;

namespace Finarteiro.Api.Common.Result;

public sealed record ValidationResult : Result, IValidationResult
{
    private ValidationResult(Error[] errors)
        : base(false, IValidationResult.ValidationError) =>
        Errors = errors;

    public Error[] Errors { get; }

    public static ValidationResult WithErrrors(Error[] errors) => new(errors);
}

public sealed record ValidationResult<TValue> : Result<TValue>, IValidationResult
{
    private ValidationResult(Error[] errors)
        : base(default, false, IValidationResult.ValidationError) =>
        Errors = errors;

    public Error[] Errors { get; }

    public static ValidationResult<TValue> WithErrrors(Error[] errors) => new(errors);
}