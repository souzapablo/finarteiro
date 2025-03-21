using Bogus;
using Finarteiro.Api.Features.Customers;

namespace Finarteiro.UnitTests.Fakers.Customers;

public static class CustomerFaker
{
    public static Customer Generate() =>
        new Faker<Customer>("pt_BR")
            .CustomInstantiator(f => new Customer(
                f.Person.FirstName,
                f.Person.LastName,
                f.Person.Email,
                f.Person.Phone
            ))
            .Generate();
}
