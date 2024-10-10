namespace Work360.Services.Leaves.Core.Exceptions;

public abstract class DomainException(string message) : Exception(message)
{
    public virtual string Code { get; }
}