namespace Ims.Domain.Customers.ValueObjects;

public class Address
{
    public string Country { get; private set; } = null!;
    public string PostalCode { get; private set; } = null!;
    public string State { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string Street { get; private set; } = null!;
    public string Number { get; private set; } = null!;
    public string Neighborhood { get; private set; } = null!;
    public string? AdditionalInfo { get; private set; }

    private Address() { }

    private Address(
        string? country,
        string? postalCode,
        string? state,
        string? city,
        string? street,
        string? number,
        string? neighborhood,
        string? additionalInfo
    )
    {
        ValidateFields(country, postalCode, state, city, street, number, neighborhood);

        Country = country!;
        PostalCode = postalCode!;
        State = state!;
        City = city!;
        Street = street!;
        Number = number!;
        Neighborhood = neighborhood!;
        AdditionalInfo = additionalInfo;
    }

    public static Address Create(
        string? country,
        string? postalCode,
        string? state,
        string? city,
        string? street,
        string? number,
        string? neighborhood,
        string? additionalInfo
    )
    {
        return new Address(
            country,
            postalCode,
            state,
            city,
            street,
            number,
            neighborhood,
            additionalInfo
        );
    }

    private void ValidateFields(
        string? country,
        string? postalCode,
        string? state,
        string? city,
        string? street,
        string? number,
        string? neighborhood
    )
    {
        if (string.IsNullOrEmpty(country))
            throw new ArgumentException("Country is required");

        if (string.IsNullOrEmpty(postalCode))
            throw new ArgumentException("Postal Code is required");

        if (string.IsNullOrEmpty(state))
            throw new ArgumentException("State is required");

        if (string.IsNullOrEmpty(city))
            throw new ArgumentException("City is required");

        if (string.IsNullOrEmpty(street))
            throw new ArgumentException("Street is required");

        if (string.IsNullOrEmpty(number))
            throw new ArgumentException("Number is required");

        if (string.IsNullOrEmpty(neighborhood))
            throw new ArgumentException("Neighborhood is required");
    }
}
