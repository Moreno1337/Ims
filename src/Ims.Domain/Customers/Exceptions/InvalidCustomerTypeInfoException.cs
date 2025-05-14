namespace Ims.Domain.Customers.Exceptions;

public class InvalidCustomerTypeInfoException : Exception
{
    public InvalidCustomerTypeInfoException(string message)
        : base(message) { }
}