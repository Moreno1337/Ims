namespace Ims.Domain.Shared.Exceptions;

public class MissingRequiredFieldException : Exception
{
    public string FieldName { get; }
    public MissingRequiredFieldException(string fieldName)
        : base($"Missing required field: {fieldName}")
    {
        FieldName = fieldName;
    }
}