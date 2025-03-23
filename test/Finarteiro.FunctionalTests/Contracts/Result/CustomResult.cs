using Finarteiro.Api.Common.Base;

namespace Finarteiro.FunctionalTests.Contracts.Result;
public class CustomResult
{
    public CustomResult() { }
    public bool IsSuccess { get; set; }
    public Error Error { get; set; } = Error.None;
}

public class CustomResult<TData>
{
    public CustomResult() { }
    public TData? Data { get; set; } = default;
    public bool IsSuccess { get; set; }
    public Error Error { get; set; } = Error.None;
}