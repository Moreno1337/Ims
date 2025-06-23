using Ims.Application.Customers.DTO;
using MediatR;

namespace Ims.Application.Customers.Queries;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerDto>>
{
    private readonly ICustomerRepository _repository;

    public GetAllCustomersHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken ct)
    {
        var result = await _repository.GetAllAsync();
        return result.Select(c => new CustomerDto()
        {
            Id = c.Id,
            Type = c.Type.ToString(),
            CPF = c.PersonInfo?.CPF.Value,
            Name = c.PersonInfo?.Name,
            BirthDate = c.PersonInfo?.BirthDate,
            CNPJ = c.CompanyInfo?.CNPJ.Value,
            CorporateName = c.CompanyInfo?.CorporateName,
            TradeName = c.CompanyInfo?.TradeName,
            StateRegistration = c.CompanyInfo?.StateRegistration,
            BillingTerm = c.CompanyInfo?.BillingTerm ?? 0,
            Interest = c.CompanyInfo?.Interest ?? 0,
            Fine = c.CompanyInfo?.Fine ?? 0,
            Phone = c.ContactInfo.Phone?.Number,
            Mobile = c.ContactInfo.Phone?.Number,
            Country = c.Address.Country,
            PostalCode = c.Address.PostalCode.Value,
            State = c.Address.State,
            City = c.Address.City,
            Street = c.Address.Street,
            Number = c.Address.Number,
            Neighborhood = c.Address.Neighborhood,
            AdditionalInfo = c.Address.AdditionalInfo,
            Notes = c.Notes,
            Emails = c.ContactInfo.Emails.Select(e => e.Address).ToList(),
        }).ToList();
    }
}