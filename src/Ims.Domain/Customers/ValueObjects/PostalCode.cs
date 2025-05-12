using System.Text.RegularExpressions;

namespace Ims.Domain.Customers.ValueObjects;

public class PostalCode
{
    public string Value { get; set; } = null!;

    private PostalCode() { }

    private PostalCode(string? postalCode)
    {
        if (string.IsNullOrEmpty(postalCode))
            throw new ArgumentException("Postal Code cannot be null or empty.", nameof(postalCode));

        if (!IsValidCpf(postalCode))
            throw new ArgumentException($"Postal Code is invalid: {postalCode} (example.: 00000-000)");

        Value = postalCode;
    }

    public static PostalCode Create(string? postalCode)
    {
        return new PostalCode(postalCode);
    }

    private bool IsValidCpf(string postalCode)
    {
        return Regex.IsMatch(postalCode,
            @"^\d{5}-\d{3}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }

    public override string ToString() => Value;

    public override bool Equals(object? obj)
    {
        if (obj is not PostalCode other)
            return false;

        return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode() => Value.ToLowerInvariant().GetHashCode();
}
