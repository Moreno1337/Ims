namespace Ims.Domain.Customers.ValueObjects;

public class ContactInfo
{
    public string? Phone { get; private set; }
    public string? Mobile { get; private set; }
    public IReadOnlyList<Email> Emails { get; private set; } = new List<Email>();

    private ContactInfo() { }

    private ContactInfo(
        string? phone,
        string? mobile,
        List<string>? emails
    )
    {
        List<Email> parsedEmails = ParseEmails(emails);

        Phone = phone;
        Mobile = mobile;
        Emails = parsedEmails;
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

    private List<Email> ParseEmails(List<string>? emails)
    {
        if (emails is null || emails.Count == 0) return new List<Email>();

        List<Email> parsedEmails = new List<Email>();

        foreach (var email in emails)
        {
            var parsedEmail = Email.Create(email);
            parsedEmails.Add(parsedEmail);
        }

        return parsedEmails;
    }
}
