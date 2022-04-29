namespace Rehsa.Core.Contracts.Rule;

public interface IRule
{
    bool Check();
    Task<bool> CheckAsync(CancellationToken cancellationToken);
}