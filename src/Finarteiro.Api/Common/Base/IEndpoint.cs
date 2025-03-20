namespace Finarteiro.Api.Common.Base;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}
