using System;

namespace AplicationLayer.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base("Error de validacion") { }
    public ValidationException(string error) : base(error) { }
}
