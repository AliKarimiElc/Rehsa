namespace Rehsa.Core.Exceptions;

/// <summary>
/// Base exception class for Rehsa Exceptions
/// </summary>
public class RehsaException : Exception
{
    /// <summary>
    /// Rehsa exception constructor
    /// </summary>
    /// <param name="message">Message for rehsa exception</param>
    protected RehsaException(string? message = null) : base(message)
    {

    }
}