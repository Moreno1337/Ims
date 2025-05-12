using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Ims.Domain.Customers.ValueObjects;

public class CNPJ
{
    public string Value { get; set; } = null!;

    private CNPJ() { }

    private CNPJ(string? cnpj)
    {
        if (string.IsNullOrEmpty(cnpj))
            throw new ArgumentException("Country is required", nameof(cnpj));

        if (!IsValidCpf(cnpj))
            throw new ArgumentException($"CNPJ is invalid: {cnpj} (example.: 12.345.678/0001-95)");

        Value = cnpj;
    }

    public static CNPJ Create(string? cnpj)
    {
        return new CNPJ(cnpj);
    }

    private bool IsValidCpf(string cnpj)
    {
        return Regex.IsMatch(cnpj,
            @"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }

    public override string ToString() => Value;

    public override bool Equals(object? obj)
    {
        if (obj is not CNPJ other)
            return false;

        return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode() => Value.ToLowerInvariant().GetHashCode();
}
