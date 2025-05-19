using Ims.Domain.Customers.ValueObjects;
using Ims.Domain.Shared.ValueObjects;

namespace Ims.Domain.Tests.Customers;

public class ContactInfoTests
{
    [Fact]
    public void Should_Create_ContactInfo_Successfully()
    {
        List<string> emails = new List<string>() { "john@example.com" };
        var phone = Phone.Create("(00) 2000-0000");
        var mobile = Mobile.Create("(00) 90000-0000");

        var contactInfo = ContactInfo.Create(phone, mobile, emails);

        Assert.NotNull(contactInfo);
        Assert.NotNull(contactInfo.Phone);
        Assert.NotNull(contactInfo.Mobile);
        Assert.True(contactInfo.Emails.Count > 0);
    }

    [Fact]
    public void Should_Create_ContactInfo_Without_Any_Info_Successfully()
    {
        var contactInfo = ContactInfo.Create(null, null, null);

        Assert.NotNull(contactInfo);
        Assert.Null(contactInfo.Phone);
        Assert.Null(contactInfo.Mobile);
        Assert.True(contactInfo.Emails.Count == 0);
    }

    [Fact]
    public void Should_Create_ContactInfo_List_Of_Emails_Successfully()
    {
        List<string> emails = new List<string>() { "john@example.com", "alice@example.com" };
        var phone = Phone.Create("(00) 2000-0000");
        var mobile = Mobile.Create("(00) 90000-0000");

        var contactInfo = ContactInfo.Create(phone, mobile, emails);

        Assert.True(contactInfo.Emails.Count > 0);
        Assert.Equal("john@example.com", contactInfo.Emails[0].Address);
        Assert.Equal("alice@example.com", contactInfo.Emails[1].Address);
    }
}