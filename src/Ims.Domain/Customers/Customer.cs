using Ims.Domain.Customers.ValueObjects;

namespace Ims.Domain.Customers;

public enum CustomerType { NaturalPerson, LegalEntity }

public class Customer
{
    public int Id { get; private set; }
    public CustomerType Type { get; private set; }
    public PersonInfo? PersonInfo { get; private set; }
    public CompanyInfo? CompanyInfo { get; private set; }
    public Address Address { get; private set; }
    public ContactInfo ContactInfo { get; private set; }
    public string? Notes { get; private set; }

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
            throw new ArgumentException("PersonInfo is required for NaturalPerson");

        if (type == CustomerType.LegalEntity && companyInfo == null)
            throw new ArgumentException("CompanyInfo is required for LegalEntity");

        if (address is null)
            throw new ArgumentException("Address info is required");

        if (contactInfo is null)
            throw new ArgumentException("Contact info is required");
    }
}
