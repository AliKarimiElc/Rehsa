using Rehsa.Core.Contracts.Rule;

namespace Rehsa.Core.Rule;

public class RuleDefinition : IRuleDefinition
{
    public RuleDefinition(string ruleName, string? obeyMessage = null, string? disObeyMessage = null,
        string? errorMessage = null)
    {
        RuleName = ruleName;
        ObeyMessage = obeyMessage;
        DisObeyMessage = disObeyMessage;
        ErrorMessage = errorMessage;
    }

    public string? RuleName { get; }
    public string? ObeyMessage { get; }
    public string? DisObeyMessage { get; }
    public string? ErrorMessage { get; }
}