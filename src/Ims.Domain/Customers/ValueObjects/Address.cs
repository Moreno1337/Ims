namespace Ims.Domain.Customers.ValueObjects;

public class Address
{
    public string Country { get; private set; } = null!;
    public PostalCode PostalCode { get; private set; } = null!;
    public string State { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string Street { get; private set; } = null!;
    public string Number { get; private set; } = null!;
    public string Neighborhood { get; private set; } = null!;
    public string? AdditionalInfo { get; private set; }

    private Address() { }

    private Address(
        string? country,
        string? postalCodeValue,
        string? state,
        string? city,
        string? street,
        string? number,
        string? neighborhood,
        string? additionalInfo
    )
    {
        PostalCode postalCode = PostalCode.Create(postalCodeValue);

        ValidateFields(
            country,
            postalCodeValue,
            state,
            city,
            street,
            number,
            neighborhood
        );

        Country = country!.ToUpper();
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
        string? postalCodeValue,
        string? state,
        string? city,
        string? street,
        string? number,
        string? neighborhood
    )
    {
        if (string.IsNullOrEmpty(country))
            throw new ArgumentException("Country is required", nameof(country));

        if (country.Length != 2)
            throw new ArgumentException("Must specify country as it's acronym (e.g. PR, SP, etc)", nameof(country));

        if (string.IsNullOrEmpty(postalCodeValue))
            throw new ArgumentException("PostalCode is required", nameof(postalCodeValue));

        if (string.IsNullOrEmpty(state))
            throw new ArgumentException("State is required", nameof(state));

        if (string.IsNullOrEmpty(city))
            throw new ArgumentException("City is required", nameof(city));

        if (string.IsNullOrEmpty(street))
            throw new ArgumentException("Street is required", nameof(street));

        if (string.IsNullOrEmpty(number))
            throw new ArgumentException("Number is required", nameof(number));

        if (string.IsNullOrEmpty(neighborhood))
            throw new ArgumentException("Neighborhood is required", nameof(neighborhood));
    }
}
