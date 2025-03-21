using Finarteiro.Api.Common.Base;

namespace Finarteiro.Api.Features.Customers;

public class Customer(string firstName, string? lastName, string? email, string? phoneNumber) 
    : Entity<CustomerId>
{
    public string FirstName { get; private set; } = firstName;
    public string? LastName { get; private set; } = lastName;
    public string? Email { get; private set; } = email;
    public string? PhoneNumber { get; private set; } = phoneNumber;
}

public class CustomerId : Id;