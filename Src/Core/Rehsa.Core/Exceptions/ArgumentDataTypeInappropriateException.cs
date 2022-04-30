using Rehsa.Core.Operators;

namespace Rehsa.Core.Exceptions;

/// <summary>
/// Exception class for inappropriate argument data type 
/// </summary>
public class ArgumentDataTypeInappropriateException : RehsaArgumentException
{
    /// <summary>
    /// ArgumentDataTypeInappropriateException constructor
    /// </summary>
    /// <param name="argumentName">Name of argument</param>
    /// <param name="message">Message of exception</param>
    public ArgumentDataTypeInappropriateException(string argumentName, string? message = null) : base(argumentName,message)
    {
        ArgumentName = argumentName;
    }
}