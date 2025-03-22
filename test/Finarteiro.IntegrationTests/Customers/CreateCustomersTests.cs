using Finarteiro.Api.Features.Customers.Create;
using System.ComponentModel;

namespace Finarteiro.IntegrationTests.Customers;
public class CreateCustomersTests(IntegrationTestWebAppFactory factory) 
    : BaseIntegrationTest(factory)
{
    [Fact, DisplayName("Should return new user guid when input is valid")]
    public async Task ShouldReturnNewUserGuid_WhenInputIsValid()
    {
        // Arrange
        var command = new CreateCustomerCommand("Pablo", "Souza", "contato@souzapablo.dev.br", "34857596575");

        // Act
        var result = await Sender.Send(command);

        Assert.True(result.IsSuccess);
        Assert.NotEqual(Guid.Empty, result.Data);
    }

}
