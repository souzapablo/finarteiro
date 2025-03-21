namespace Finarteiro.Api.Common.Base;

public class Error(string code, string message)
{
    public string Code { get; private set; } = code;
    public string Message { get; set; } = message;


    public static readonly Error None = new(string.Empty, string.Empty);

    public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");

    public static readonly Error ConditionNotMet = new("Error.ConditionNotMet", "The specified condition was not met.");
}
