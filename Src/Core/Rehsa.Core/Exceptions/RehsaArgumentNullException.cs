namespace Rehsa.Core.Exceptions;

/// <summary>
/// Rehsa argument null exception
/// </summary>
public class RehsaArgumentNullException : RehsaArgumentException
{
    /// <summary>
    /// Create rehsa argument null exception
    /// </summary>
    /// <param name="argumentName">Argument name</param>
    /// <param name="message">Message of exception</param>
    public RehsaArgumentNullException(string argumentName,string? message = null):base(argumentName,message)
    {
        
    }
}