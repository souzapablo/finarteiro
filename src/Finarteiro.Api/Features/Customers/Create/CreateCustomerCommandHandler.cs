using Finarteiro.Api.Common.Result;
using Finarteiro.Api.Infrastructure;
using MediatR;

namespace Finarteiro.Api.Features.Customers.Create;

public class CreateCustomerCommandHandler(AppDbContext context) : IRequestHandler<CreateCustomerCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(request.FirstName, request.LastName, request.Email, request.PhoneNumber);

        context.Customers.Add(customer);
        await context.SaveChangesAsync(cancellationToken);

        return customer.Id.Value;
    }
}
