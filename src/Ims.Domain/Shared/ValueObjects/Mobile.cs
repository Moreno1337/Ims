using System.Text.RegularExpressions;

namespace Ims.Domain.Shared.ValueObjects;

public class Mobile
{
    public string Number { get; set; } = null!;

    private Mobile() { }

    private Mobile(string? number)
    {
        if (string.IsNullOrEmpty(number))
            throw new ArgumentException("Mobile number cannot be null or empty.", nameof(number));

        if (!IsValidNumber(number))
            throw new ArgumentException($"Invalid mobile number: {number} (example.: (00) 00000-0000)");

        Number = number;
    }

    public static Mobile Create(string? number)
    {
        return new Mobile(number);
    }

    private bool IsValidNumber(string number)
    {
        return Regex.IsMatch(number,
            @"^\(\d{2}\)\s9\d{4}-\d{4}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }

    public override string ToString() => Number;

    public override bool Equals(object? obj)
    {
        if (obj is not Mobile other)
            return false;

        return Number.Equals(other.Number, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode() => Number.ToLowerInvariant().GetHashCode();
}
