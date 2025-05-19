using Ims.Domain.Shared.Exceptions;
using Ims.Domain.Shared.ValueObjects;

namespace Ims.Domain.Customers.ValueObjects;

public class CompanyInfo
{
    public CNPJ CNPJ { get; private set; } = null!;
    public string CorporateName { get; private set; } = null!;
    public string? TradeName { get; private set; }
    public string? StateRegistration { get; private set; }
    public int BillingTerm { get; private set; }
    public decimal Interest { get; private set; }
    public decimal Fine { get; private set; }

    private CompanyInfo() { }

    private CompanyInfo(
        string? cnpjValue,
        string? corporateName,
        string? tradeName,
        string? stateRegistration,
        int billingTerm,
        decimal interest,
        decimal fine
    )
    {
        CNPJ cnpj = CNPJ.Create(cnpjValue);

        if (string.IsNullOrEmpty(corporateName))
            throw new MissingRequiredFieldException(nameof(CorporateName));

        CNPJ = cnpj;
        CorporateName = corporateName;
        TradeName = tradeName;
        StateRegistration = stateRegistration;
        BillingTerm = billingTerm;
        Interest = interest;
        Fine = fine;
    }

    public static CompanyInfo Create(
        string? cnpj,
        string? corporateName,
        string? tradeName,
        string? stateRegistration,
        int billingTerm,
        decimal interest,
        decimal fine
    )
    {
        return new CompanyInfo(
            cnpj,
            corporateName,
            tradeName,
            stateRegistration,
            billingTerm,
            interest,
            fine
        );
    }
}
