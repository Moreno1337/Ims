namespace Ims.Domain.Customers.ValueObjects;

public class ContactInfo
{
    public string? Phone { get; private set; }
    public string? Mobile { get; private set; }
    public List<string>? Emails { get; private set; }

    private ContactInfo() { }

    private ContactInfo(
        string? phone,
        string? mobile,
        List<string>? emails
    )
    {
        Phone = phone;
        Mobile = mobile;
        Emails = emails;
    }

    public static ContactInfo Create(
        string? phone,
        string? mobile,
        List<string>? emails
    )
    {
        return new ContactInfo(
            phone,
            mobile,
            emails
        );
    }
}
