using Finarteiro.Api.Common.Base;

namespace Finarteiro.Api.Features.Customers;

public class Customer : Entity
{
    private Customer() { }

    public Customer(string firstName, string? lastName, string? email, string? phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber; 
    }

    public string FirstName { get; private set; } = string.Empty;
    public string? LastName { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
}
