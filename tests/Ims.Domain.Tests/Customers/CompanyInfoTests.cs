using Ims.Domain.Customers.ValueObjects;
using Ims.Domain.Shared.Exceptions;

namespace Ims.Domain.Tests.Customers;

public class CompanyInfoTests
{
    [Fact]
    public void Should_Create_CompanyInfo_Successfully()
    {
        var companyInfo = CompanyInfo.Create(
            "00.000.000/0000-00",
            "John Doe LTDA",
            "John Doe Business",
            null,
            0,
            0,
            0
        );

        Assert.NotNull(companyInfo);
        Assert.NotNull(companyInfo.CNPJ);
        Assert.NotNull(companyInfo.CorporateName);
    }

    [Fact]
    public void Should_Throw_When_Creating_CompanyInfo_With_Null_CorporateName()
    {
        var ex = Assert.Throws<MissingRequiredFieldException>(() =>
        {
            CompanyInfo.Create(
                "00.000.000/0000-00",
                null,
                "John Doe Business",
                null,
                0,
                0,
                0
            );
        });

        Assert.Equal(nameof(CompanyInfo.CorporateName), ex.FieldName);
    }

    [Fact]
    public void Should_Throw_When_Creating_CompanyInfo_With_Blank_CorporateName()
    {
        var ex = Assert.Throws<MissingRequiredFieldException>(() =>
        {
            CompanyInfo.Create(
                "00.000.000/0000-00",
                "",
                "John Doe Business",
                null,
                0,
                0,
                0
            );
        });

        Assert.Equal(nameof(CompanyInfo.CorporateName), ex.FieldName);
    }
}