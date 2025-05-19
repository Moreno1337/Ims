using Ims.Domain.Customers.ValueObjects;
using Ims.Domain.Shared.Exceptions;

namespace Ims.Domain.Tests.Customers;

public class PersonInfoTests
{
    [Fact]
    public void Should_Create_PersonInfo_Successfully()
    {
        var personInfo = PersonInfo.Create(
            "000.000.000-00",
            "John Doe",
            new DateTime(1990, 1, 1)
        );

        Assert.NotNull(personInfo);
        Assert.NotNull(personInfo.CPF);
        Assert.NotNull(personInfo.Name);
        Assert.True(personInfo.BirthDate == new DateTime(1990, 1, 1));
    }

    [Fact]
    public void Should_Throw_When_Creating_PersonInfo_With_Null_Name()
    {
        var ex = Assert.Throws<MissingRequiredFieldException>(() =>
        {
            PersonInfo.Create(
                "000.000.000-00",
                null,
                new DateTime(1990, 1, 1)
            );
        });

        Assert.Equal(nameof(PersonInfo.Name), ex.FieldName);
    }

    [Fact]
    public void Should_Throw_When_Creating_PersonInfo_With_Blank_Name()
    {
        var ex = Assert.Throws<MissingRequiredFieldException>(() =>
        {
            PersonInfo.Create(
                "000.000.000-00",
                "",
                new DateTime(1990, 1, 1)
            );
        });

        Assert.Equal(nameof(PersonInfo.Name), ex.FieldName);
    }

    [Fact]
    public void Should_Throw_When_Creating_PersonInfo_With_Null_BirthDate()
    {
        var ex = Assert.Throws<MissingRequiredFieldException>(() =>
        {
            PersonInfo.Create(
                "000.000.000-00",
                "John Doe",
                null
            );
        });

        Assert.Equal(nameof(PersonInfo.BirthDate), ex.FieldName);
    }
}