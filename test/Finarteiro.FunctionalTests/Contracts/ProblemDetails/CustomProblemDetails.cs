using Finarteiro.Api.Common.Base;

namespace Finarteiro.FunctionalTests.Contracts.ProblemDetails;
public class CustomProblemDetails
{
    public string Type { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int Status { get; set; }
    public string Detail { get; set; } = string.Empty;
    public List<Error> Errors { get; set; } = [];
}
 