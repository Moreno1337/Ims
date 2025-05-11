using System.Text.RegularExpressions;

namespace Ims.Domain.Customers.ValueObjects;

public class Email
{
    public string Address { get; private set; } = null!;

    private Email() { }

    private Email(string? email)
    {
        if (string.IsNullOrEmpty(email))
            throw new ArgumentException("Invalid e-mail address (was empty)");

        if (!IsValidEmail(email))
            throw new ArgumentException($"Invalid email address: {email}");

        Address = email!;
    }

    public static Email Create(string? email)
    {
        return new Email(email);
    }

    private static bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }

    public override string ToString() => Address;

    public override bool Equals(object? obj)
    {
        if (obj is not Email other)
            return false;

        return Address.Equals(other.Address, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode() => Address.ToLowerInvariant().GetHashCode();
}
