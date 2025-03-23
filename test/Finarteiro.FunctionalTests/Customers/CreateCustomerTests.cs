using Finarteiro.Api.Features.Customers.Create;
using Finarteiro.FunctionalTests.Contracts.Result;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http.Json;

namespace Finarteiro.FunctionalTests.Customers;
public class CreateCustomerTests(FunctionalTestWebAppFactory factory)
    : BaseFunctionalTest(factory)
{
    [Fact]
    public async Task ShouldReturnCreated_WhenInputIsValid()
    {
        // Arrange
        var request = new CreateCustomerCommand("Pablo", "Souza", "oliveirasouzapablo@gmail.com", "12345678912");

        // Act
        var response = await HttpClient.PostAsJsonAsync("api/v1/customers", request);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<CustomResult<Guid>>();
        Assert.NotEqual(Guid.Empty, result?.Data);
    }
}
