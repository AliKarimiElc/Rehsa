using Rehsa.Core.Operators;

namespace Rehsa.Core.Exceptions;

/// <summary>
/// Base class for all of rehsa argument exception
/// </summary>
public class RehsaArgumentException:RehsaException
{
    /// <summary>
    /// Name of argument
    /// </summary>
    public string ArgumentName { get; protected set; }
    /// <summary>
    /// Create rehsa argument exception
    /// </summary>
    /// <param name="argumentName">Argument name</param>
    /// <param name="message">Message of exception</param>
    protected RehsaArgumentException(string argumentName, string? message) : base(message)
    {
        ArgumentName = argumentName;
    }
}