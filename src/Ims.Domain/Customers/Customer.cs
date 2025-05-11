using Ims.Domain.Customers.ValueObjects;

namespace Ims.Domain.Customers;

public enum CustomerType { NaturalPerson, LegalEntity }

public class Customer
{
    public int Id { get; private set; }
    public CustomerType Type { get; set; }
    public PersonInfo? PersonInfo { get; private set; }
    public CompanyInfo? CompanyInfo { get; private set; }
    public Address Address { get; private set; }
    public ContactInfo ContactInfo { get; private set; }
    public string? Notes { get; private set; }

    private Customer(
        CustomerType? type,
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
        if (type is null)
            throw new ArgumentNullException(nameof(Type));

        PersonInfo? personInfo = null;
        CompanyInfo? companyInfo = null;

        if (type == CustomerType.NaturalPerson)
        {
            personInfo = PersonInfo.Create(
                cpf,
                name,
                birthDate
            );
        }

        if (type == CustomerType.LegalEntity)
        {
            companyInfo = CompanyInfo.Create(
                cnpj,
                corporateName,
                tradeName,
                stateRegistration,
                billingTerm,
                interest,
                fine
            );
        }

        var address = Address.Create(
            country,
            postalCode,
            state,
            city,
            street,
            number,
            neighborhood,
            additionalInfo
        );

        var contactInfo = ContactInfo.Create(
            phone,
            mobile,
            emails
        );

        PersonInfo = personInfo;
        CompanyInfo = companyInfo;
        Address = address;
        ContactInfo = contactInfo;
        Notes = notes;
    }

    public static Customer Create(
        CustomerType? type,
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
        CustomerType? type,
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
        if (type is null)
            throw new ArgumentNullException(nameof(Type));

        PersonInfo? personInfo = null;
        CompanyInfo? companyInfo = null;

        if (type == CustomerType.NaturalPerson)
        {
            personInfo = PersonInfo.Create(
                cpf,
                name,
                birthDate
            );
        }

        if (type == CustomerType.LegalEntity)
        {
            companyInfo = CompanyInfo.Create(
                cnpj,
                corporateName,
                tradeName,
                stateRegistration,
                billingTerm,
                interest,
                fine
            );
        }

        var address = Address.Create(
            country,
            postalCode,
            state,
            city,
            street,
            number,
            neighborhood,
            additionalInfo
        );

        var contactInfo = ContactInfo.Create(
            phone,
            mobile,
            emails
        );

        PersonInfo = personInfo;
        CompanyInfo = companyInfo;
        Address = address;
        ContactInfo = contactInfo;
        Notes = notes;
    }
}
