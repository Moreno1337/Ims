using System.Text.RegularExpressions;

namespace Ims.Domain.Customers.ValueObjects;

public class CPF
{
    public string Value { get; set; } = null!;

    private CPF() { }

    private CPF(string? cpf)
    {
        if (string.IsNullOrEmpty(cpf))
            throw new ArgumentException("CPF cannot be null or empty.", nameof(cpf));

        if (!IsValidCpf(cpf))
            throw new ArgumentException($"CPF is invalid: {cpf} (example.: 123.456.789-00)");

        Value = cpf;
    }

    public static CPF Create(string? cpf)
    {
        return new CPF(cpf);
    }

    private bool IsValidCpf(string cpf)
    {
        return Regex.IsMatch(cpf,
            @"^\d{3}\.\d{3}\.\d{3}-\d{2}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }

    public override string ToString() => Value;

    public override bool Equals(object? obj)
    {
        if (obj is not CPF other)
            return false;

        return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode() => Value.ToLowerInvariant().GetHashCode();
}
