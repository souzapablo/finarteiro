using Finarteiro.Api.Infrastructure;
using MediatR;

namespace Finarteiro.Api.Features.Customers.Create;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly AppDbContext _context;

    public CreateCustomerCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(request.FirstName, request.LastName, request.Email, request.PhoneNumber);

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync(cancellationToken);

        return customer.Id;
    }
}
