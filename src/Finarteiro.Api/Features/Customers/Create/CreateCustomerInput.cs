namespace Finarteiro.Api.Features.Customers.Create;

public record CreateCustomerInput(
    string FirstName,
    string? LastName,
    string? Email,
    string? PhoneNumber);

public static class CreateCustomerInputExtensions
{
    public static CreateCustomerCommand ToCommand(this CreateCustomerInput input) =>
        new(input.FirstName, input.LastName, input.Email, input.PhoneNumber);
}