using Finarteiro.Api.Common.Base;

namespace Finarteiro.Api.Common.Result;

public interface IValidationResult
{
    public static readonly Error ValidationError = new("VALIDATION_ERROR", "One ore more validation errors occurred.");
    Error[] Errors { get; }
}