using MediatR;

namespace Finarteiro.Api.Features.Customers.Create;

public record CreateCustomerCommand(
    string FirstName,
    string? LastName,
    string? Email,
    string? PhoneNumber) : IRequest<Guid>;