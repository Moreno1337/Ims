using Ims.Domain.Customers.Exceptions;
using Ims.Domain.Customers.ValueObjects;
using Ims.Domain.Shared.Exceptions;
using Ims.Domain.Shared.Interfaces;
using Ims.Domain.Shared.ValueObjects;

namespace Ims.Domain.Customers;

public enum CustomerType { NaturalPerson, LegalEntity }

public class Customer : IAuditable, IHasTenant
{
    public int Id { get; private set; }
    public CustomerType Type { get; private set; }
    public PersonInfo? PersonInfo { get; private set; }
    public CompanyInfo? CompanyInfo { get; private set; }
    public Address Address { get; private set; } = null!;
    public ContactInfo ContactInfo { get; private set; } = null!;
    public string? Notes { get; private set; }

    private Customer() { }

    private Customer(
        CustomerType type,
        PersonInfo? personInfo,
        CompanyInfo? companyInfo,
        Address? address,
        ContactInfo? contactInfo,
        string? notes
    )
    {
        ValidateFields(type, personInfo, companyInfo, address, contactInfo);

        PersonInfo = personInfo;
        CompanyInfo = companyInfo;
        Address = address!;
        ContactInfo = contactInfo!;
        Notes = notes;
    }

    public static Customer Create(
        CustomerType type,
        PersonInfo? personInfo,
        CompanyInfo? companyInfo,
        Address? address,
        ContactInfo? contactInfo,
        string? notes
    )
    {
        return new Customer(
            type,
            personInfo,
            companyInfo,
            address,
            contactInfo,
            notes
        );
    }

    public void Update(
        CustomerType type,
        PersonInfo? personInfo,
        CompanyInfo? companyInfo,
        Address? address,
        ContactInfo? contactInfo,
        string? notes
    )
    {
        ValidateFields(type, personInfo, companyInfo, address, contactInfo);

        PersonInfo = personInfo;
        CompanyInfo = companyInfo;
        Address = address!;
        ContactInfo = contactInfo!;
        Notes = notes;
    }

    private void ValidateFields(
        CustomerType type,
        PersonInfo? personInfo,
        CompanyInfo? companyInfo,
        Address? address,
        ContactInfo? contactInfo
    )
    {
        if (type == CustomerType.NaturalPerson && personInfo == null)
            throw new MissingRequiredFieldException(nameof(PersonInfo));

        if (type == CustomerType.NaturalPerson && companyInfo != null)
            throw new InvalidCustomerTypeInfoException(nameof(CompanyInfo));

        if (type == CustomerType.LegalEntity && companyInfo == null)
            throw new MissingRequiredFieldException(nameof(CompanyInfo));

        if (type == CustomerType.LegalEntity && personInfo != null)
            throw new InvalidCustomerTypeInfoException(nameof(PersonInfo));

        if (address is null)
            throw new MissingRequiredFieldException(nameof(Address));

        if (contactInfo is null)
            throw new MissingRequiredFieldException(nameof(ContactInfo));
    }
}
