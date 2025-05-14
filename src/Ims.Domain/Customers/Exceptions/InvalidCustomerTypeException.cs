namespace Ims.Domain.Customers.Exceptions;

public class InvalidCustomerTypeException : Exception
{
    public InvalidCustomerTypeException(string message)
        : base(message) { }
}