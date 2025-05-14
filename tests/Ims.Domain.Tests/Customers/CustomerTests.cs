using Ims.Domain.Customers;
using Ims.Domain.Customers.Exceptions;
using Ims.Domain.Customers.ValueObjects;

namespace Ims.Domain.Tests.Customers;

public class CustomerTests
{
    private PersonInfo CreateValidPersonInfo() => PersonInfo.Create("000.000.000-00", "John Doe", new DateTime(1990, 1, 1));

    private CompanyInfo CreateValidCompanyInfo() => CompanyInfo.Create("00.000.000/0000-00", "John Doe LTDA", "John Doe Business", null, 0, 0, 0);

    private Address CreateValidAddress() => Address.Create("Brasil", "00000-000", "SP", "São Paulo", "Street X", "123", "Centro", null);

    private ContactInfo CreateValidContactInfo()
    {
        List<string> emails = new List<string>() { "john@example.com" };
        var phone = Phone.Create("(00) 2000-0000");
        var mobile = Mobile.Create("(00) 90000-0000");

        return ContactInfo.Create(phone, mobile, emails);
    }

    [Fact]
    public void Should_Create_NaturalPerson_Customer_Successfully()
    {
        var personInfo = CreateValidPersonInfo();
        var address = CreateValidAddress();
        var contact = CreateValidContactInfo();

        var customer = Customer.Create(
            CustomerType.NaturalPerson,
            personInfo,
            null,
            address,
            contact,
            "Test note"
        );

        Assert.NotNull(customer);
        Assert.Equal(CustomerType.NaturalPerson, customer.Type);
        Assert.NotNull(customer.PersonInfo);
        Assert.Null(customer.CompanyInfo);
        Assert.NotNull(customer.Address);
        Assert.NotNull(customer.ContactInfo);
    }

    [Fact]
    public void Should_Throw_When_Creating_LegalEntity_Without_CompanyInfo()
    {
        var address = CreateValidAddress();
        var contact = CreateValidContactInfo();

        var ex = Assert.Throws<MissingRequiredFieldException>(() =>
        {
            Customer.Create(
                CustomerType.LegalEntity,
                null,
                null,
                address,
                contact,
                null
            );
        });

        Assert.Equal(nameof(Customer.CompanyInfo), ex.FieldName);
    }

    [Fact]
    public void Should_Throw_When_Creating_LegalEntity_With_PersonInfo()
    {
        var personInfo = CreateValidPersonInfo();
        var companyInfo = CreateValidCompanyInfo();
        var address = CreateValidAddress();
        var contact = CreateValidContactInfo();

        var ex = Assert.Throws<InvalidCustomerTypeInfoException>(() =>
        {
            Customer.Create(
                CustomerType.LegalEntity,
                personInfo,
                companyInfo,
                address,
                contact,
                null
            );
        });
    }

    [Fact]
    public void Should_Throw_When_Creating_NaturalPerson_Without_PersonInfo()
    {
        var address = CreateValidAddress();
        var contact = CreateValidContactInfo();

        var ex = Assert.Throws<MissingRequiredFieldException>(() =>
        {
            Customer.Create(
                CustomerType.NaturalPerson,
                null,
                null,
                address,
                contact,
                null
            );
        });

        Assert.Equal(nameof(Customer.PersonInfo), ex.FieldName);
    }

    [Fact]
    public void Should_Throw_When_Creating_NaturalPerson_With_CompanyInfo()
    {
        var personInfo = CreateValidPersonInfo();
        var companyInfo = CreateValidCompanyInfo();
        var address = CreateValidAddress();
        var contact = CreateValidContactInfo();

        var ex = Assert.Throws<InvalidCustomerTypeInfoException>(() =>
        {
            Customer.Create(
                CustomerType.NaturalPerson,
                personInfo,
                companyInfo,
                address,
                contact,
                null
            );
        });
    }

    [Fact]
    public void Should_Throw_When_Creating_Customer_Without_Address()
    {
        var personInfo = CreateValidPersonInfo();
        var contact = CreateValidContactInfo();

        var ex = Assert.Throws<MissingRequiredFieldException>(() =>
        {
            Customer.Create(
                CustomerType.NaturalPerson,
                personInfo,
                null,
                null,
                contact,
                null
            );
        });

        Assert.Equal(nameof(Customer.Address), ex.FieldName);
    }

    [Fact]
    public void Should_Throw_When_Creating_Customer_Without_ContactInfo()
    {
        var personInfo = CreateValidPersonInfo();
        var address = CreateValidAddress();

        var ex = Assert.Throws<MissingRequiredFieldException>(() =>
        {
            Customer.Create(
                CustomerType.NaturalPerson,
                personInfo,
                null,
                address,
                null,
                null
            );
        });

        Assert.Equal(nameof(Customer.ContactInfo), ex.FieldName);
    }
}
