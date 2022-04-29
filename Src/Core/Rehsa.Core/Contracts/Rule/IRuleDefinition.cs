namespace Rehsa.Core.Contracts.Rule;

public interface IRuleDefinition
{
    string RuleName { get; }
    string? ObeyMessage { get; }
    string? DisObeyMessage { get; }
    string? ErrorMessage { get; }
}