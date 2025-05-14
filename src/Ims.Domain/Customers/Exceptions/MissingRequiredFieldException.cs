namespace Ims.Domain.Customers.Exceptions;

public class MissingRequiredFieldException : Exception
{
    public string FieldName { get; }
    public MissingRequiredFieldException(string fieldName)
        : base($"Missing required field: {fieldName}")
    {
        FieldName = fieldName;
    }
}