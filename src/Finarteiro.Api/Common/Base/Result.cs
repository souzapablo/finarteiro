using System.Text.Json.Serialization;

namespace Finarteiro.Api.Common.Base;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    [JsonIgnore]
    public bool IsFailure => !IsSuccess;

    [JsonIgnore]
    public Error Error { get; }

    public static Result Success() => new(true, Error.None);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

    public static Result Create(bool condition) => condition ? Success() : Failure(Error.ConditionNotMet);

    public static Result<TValue> Create<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}

public class Result<TData> : Result
{
    private readonly TData? _data;

    protected internal Result(TData? value, bool isSuccess, Error error)
        : base(isSuccess, error) =>
        _data = value;

    public TData Data => IsSuccess
        ? _data!
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    public static implicit operator Result<TData>(TData? value) => Create(value);
}