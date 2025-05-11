namespace Ims.Domain.Customers;

public class Customer
{
    public int Id { get; private set; }
    public string? Type { get; private set; }
    public string? CPF { get; private set; }
    public string? Name { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public string? CNPJ { get; private set; }
    public string? CorporateName { get; private set; }
    public string? TradeName { get; private set; }
    public string? StateRegistration { get; private set; }
    public int BillingTerm { get; private set; }
    public decimal Interest { get; private set; }
    public decimal Fine { get; private set; }
    public string? Phone { get; private set; }
    public string? Mobile { get; private set; }
    public string? Country { get; private set; }
    public string? PostalCode { get; private set; }
    public string? State { get; private set; }
    public string? City { get; private set; }
    public string? Street { get; private set; }
    public string? Number { get; private set; }
    public string? Neighborhood { get; private set; }
    public string? AdditionalInfo { get; private set; }
    public string? Notes { get; private set; }
    public List<string> Emails { get; private set; } = new List<string>();

    private Customer(
        string? type,
        string? cpf,
        string? name,
        DateTime? birthDate,
        string? cnpj,
        string? corporateName,
        string? tradeName,
        string? stateRegistration,
        int billingTerm,
        decimal interest,
        decimal fine,
        string? phone,
        string? mobile,
        string? country,
        string? postalCode,
        string? state,
        string? city,
        string? street,
        string? number,
        string? neighborhood,
        string? additionalInfo,
        string? notes,
        List<string> emails
    )
    {
        Type = type;
        CPF = cpf;
        Name = name;
        BirthDate = birthDate;
        CNPJ = cnpj;
        CorporateName = corporateName;
        TradeName = tradeName;
        StateRegistration = stateRegistration;
        BillingTerm = billingTerm;
        Interest = interest;
        Fine = fine;
        Phone = phone;
        Mobile = mobile;
        Country = country;
        PostalCode = postalCode;
        State = state;
        City = city;
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        AdditionalInfo = additionalInfo;
        Notes = notes;
        Emails = emails;
    }

    public static Customer Create(
        string? type,
        string? cpf,
        string? name,
        DateTime? birthDate,
        string? cnpj,
        string? corporateName,
        string? tradeName,
        string? stateRegistration,
        int billingTerm,
        decimal interest,
        decimal fine,
        string? phone,
        string? mobile,
        string? country,
        string? postalCode,
        string? state,
        string? city,
        string? street,
        string? number,
        string? neighborhood,
        string? additionalInfo,
        string? notes,
        List<string> emails
    )
    {
        return new Customer(
            type,
            cpf,
            name,
            birthDate,
            cnpj,
            corporateName,
            tradeName,
            stateRegistration,
            billingTerm,
            interest,
            fine,
            phone,
            mobile,
            country,
            postalCode,
            state,
            city,
            street,
            number,
            neighborhood,
            additionalInfo,
            notes,
            emails
        );
    }

    public void Update(
        string? type,
        string? cpf,
        string? name,
        DateTime? birthDate,
        string? cnpj,
        string? corporateName,
        string? tradeName,
        string? stateRegistration,
        int billingTerm,
        decimal interest,
        decimal fine,
        string? phone,
        string? mobile,
        string? country,
        string? postalCode,
        string? state,
        string? city,
        string? street,
        string? number,
        string? neighborhood,
        string? additionalInfo,
        string? notes,
        List<string> emails
    )
    {
        Type = type;
        CPF = cpf;
        Name = name;
        BirthDate = birthDate;
        CNPJ = cnpj;
        CorporateName = corporateName;
        TradeName = tradeName;
        StateRegistration = stateRegistration;
        BillingTerm = billingTerm;
        Interest = interest;
        Fine = fine;
        Phone = phone;
        Mobile = mobile;
        Country = country;
        PostalCode = postalCode;
        State = state;
        City = city;
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        AdditionalInfo = additionalInfo;
        Notes = notes;
        Emails = emails;
    }
}
