using Finarteiro.Api.Common.Base;
using Finarteiro.Api.Features.Customers.Create;

namespace Finarteiro.Api.Features.Customers;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this WebApplication app)
    {
       app.MapGroup("api/v1/customers")
            .WithTags("Customers")
            .MapEndpoint<CreateCustomerEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
    where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}