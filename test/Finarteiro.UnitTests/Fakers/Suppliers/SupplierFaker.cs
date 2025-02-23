using Bogus;
using Bogus.Extensions.Brazil;
using Finarteiro.Api.Features.Suppliers;

namespace Finarteiro.UnitTests.Fakers.Suppliers;

public static class SupplierFaker
{
    public static Supplier Generate() =>
        new Faker<Supplier>()
            .CustomInstantiator(f => new Supplier(
                f.Company.CompanyName(),
                f.Company.Cnpj(),
                f.Person.Phone
            ))
            .Generate();
}
