using System.Text.RegularExpressions;

namespace Ims.Domain.Customers.ValueObjects;

public class Phone
{
    public string Number { get; set; } = null!;

    private Phone() { }

    private Phone(string? number)
    {
        if (string.IsNullOrEmpty(number))
            throw new ArgumentException("Phone number cannot be null or empty.", nameof(number));

        if (!IsValidNumber(number))
            throw new ArgumentException($"Invalid phone number: {number} (example.: (00) 0000-0000)");

        Number = number;
    }

    public static Phone Create(string? number)
    {
        return new Phone(number);
    }

    private bool IsValidNumber(string number)
    {
        return Regex.IsMatch(number,
            @"^\(\d{2}\)\s[2-5]\d{3}-\d{4}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }

    public override string ToString() => Number;

    public override bool Equals(object? obj)
    {
        if (obj is not Phone other)
            return false;

        return Number.Equals(other.Number, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode() => Number.ToLowerInvariant().GetHashCode();
}
