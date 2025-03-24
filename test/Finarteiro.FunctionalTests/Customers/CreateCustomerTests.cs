using Finarteiro.Api.Features.Customers;
using Finarteiro.Api.Features.Customers.Create;
using Finarteiro.FunctionalTests.Contracts.Result;
using Finarteiro.FunctionalTests.Extensions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http.Json;

namespace Finarteiro.FunctionalTests.Customers;
public class CreateCustomerTests(FunctionalTestWebAppFactory factory)
    : BaseFunctionalTest(factory)
{
    [Theory]
    [InlineData("Pablo", "Souza", "oliveirasouzapablo@gmail.com", "12345678912")]
    [InlineData("Pablo", null, null, null)]
    public async Task ShouldReturnCreated_WhenInputIsValid(string firstName, string? lastName, string? email, string? phoneNumber)
    {
        // Arrange
        var request = new CreateCustomerCommand(firstName, lastName, email, phoneNumber);

        // Act
        var response = await HttpClient.PostAsJsonAsync("api/v1/customers", request);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<CustomResult<Guid>>();
        Assert.NotEqual(Guid.Empty, result?.Data);
    }

    [Fact]
    public async Task ShouldReturnUnprocessableEntity_WhenInputEmailIsInvalid()
    {
        // Arrange
        var request = new CreateCustomerCommand("Pablo", "Souza", "email", "12345678912");

        // Act
        var response = await HttpClient.PostAsJsonAsync("api/v1/customers", request);

        // Assertd
        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);

        var result = await response.GetProblemDetails();

        Assert.Contains(CustomerErrors.CreateUser.InvalidEmail.Message, result.Errors.Select(e => e.Message));
    }

    [Fact]
    public async Task ShouldReturnUnprocessableEntity_WhenFirstNameIsMissing()
    {
        // Arrange
        var request = new CreateCustomerCommand(null!, "Souza", "oliveirasouzapablo@gmail.com", "12345678912");

        // Act
        var response = await HttpClient.PostAsJsonAsync("api/v1/customers", request);

        // Assertd
        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);

        var result = await response.GetProblemDetails();

        Assert.Contains(CustomerErrors.CreateUser.MissingFirstName.Message, result.Errors.Select(e => e.Message));
    }

    [Fact]
    public async Task ShouldReturnUnprocessableEntity_WhenFirstNameIsInvalid()
    {
        // Arrange
        var request = new CreateCustomerCommand("ThisIsAVeryLongNameVeryLongIndeedAndShouldntBeUsedByAnyone",
            "Souza", "oliveirasouzapablo@gmail.com", "12345678912");

        // Act
        var response = await HttpClient.PostAsJsonAsync("api/v1/customers", request);

        // Assertd
        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);

        var result = await response.GetProblemDetails();

        Assert.Contains(CustomerErrors.CreateUser.InvalidFirstName.Message, result.Errors.Select(e => e.Message));
    }

    [Fact]
    public async Task ShouldReturnUnprocessableEntity_WhenLastNameIsInvalid()
    {
        // Arrange
        var request = new CreateCustomerCommand("Pablo",
            "ThisIsAVeryLongNameVeryLongIndeedAndShouldntBeUsedByAnyone", "oliveirasouzapablo@gmail.com", "12345678912");

        // Act
        var response = await HttpClient.PostAsJsonAsync("api/v1/customers", request);

        // Assertd
        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);

        var result = await response.GetProblemDetails();

        Assert.Contains(CustomerErrors.CreateUser.InvalidLastName.Message, result.Errors.Select(e => e.Message));
    }

    [Theory]
    [InlineData("1")] // 1 character
    [InlineData("123456789")] // 10 characters
    [InlineData("123456789123")] // 12 characters
    public async Task ShouldReturnUnprocessableEntity_WhenPhoneNumberIsInvalid(string phoneNumber)
    {
        // Arrange
        var request = new CreateCustomerCommand("Pablo", "Souza", "oliveirasouzapablo@gmail.com", phoneNumber);

        // Act
        var response = await HttpClient.PostAsJsonAsync("api/v1/customers", request);

        // Assertd
        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);

        var result = await response.GetProblemDetails();

        Assert.Contains(CustomerErrors.CreateUser.InvalidPhoneNumber.Message, result.Errors.Select(e => e.Message));
    }
}
