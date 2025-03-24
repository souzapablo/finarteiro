using Finarteiro.FunctionalTests.Contracts.ProblemDetails;
using System.Net.Http.Json;

namespace Finarteiro.FunctionalTests.Extensions;
public static class HttpResponseMessageExtensions
{
    public static async Task<CustomProblemDetails> GetProblemDetails(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
            throw new InvalidOperationException("Successuful response");

        var problemDetails = await response.Content
                    .ReadFromJsonAsync<CustomProblemDetails>();

        if (problemDetails is null)
            throw new InvalidOperationException("Null problem details.");

        return problemDetails;
    }
}
