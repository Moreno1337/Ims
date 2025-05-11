using MediatR;

namespace Ims.Application.Customers.Commands;

public record CreateCustomerCommand : IRequest<int>
{
    public string? Type { get; set; }
    public string? CPF { get; set; }
    public string? Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? CNPJ { get; set; }
    public string? CorporateName { get; set; }
    public string? TradeName { get; set; }
    public string? StateRegistration { get; set; }
    public int BillingTerm { get; set; }
    public decimal Interest { get; set; }
    public decimal Fine { get; set; }
    public string? Phone { get; set; }
    public string? Mobile { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? Number { get; set; }
    public string? Neighborhood { get; set; }
    public string? AdditionalInfo { get; set; }
    public string? Notes { get; set; }
    public List<string> Emails { get; set; } = new List<string>();
}
