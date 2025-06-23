using Ims.Application.Customers.DTO;
using MediatR;

namespace Ims.Application.Customers.Queries;

public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
{
    private readonly ICustomerRepository _repository;

    public GetCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken ct)
    {
        var result = await _repository.GetAsync(request.Id);

        if (result is null)
            throw new KeyNotFoundException($"This customer id was not found in the database ({request.Id})");

        var response = new CustomerDto()
        {
            Id = result.Id,
            Type = result.Type.ToString(),
            CPF = result.PersonInfo?.CPF.Value,
            Name = result.PersonInfo?.Name,
            BirthDate = result.PersonInfo?.BirthDate,
            CNPJ = result.CompanyInfo?.CNPJ.Value,
            CorporateName = result.CompanyInfo?.CorporateName,
            TradeName = result.CompanyInfo?.TradeName,
            StateRegistration = result.CompanyInfo?.StateRegistration,
            BillingTerm = result.CompanyInfo?.BillingTerm ?? 0,
            Interest = result.CompanyInfo?.Interest ?? 0,
            Fine = result.CompanyInfo?.Fine ?? 0,
            Phone = result.ContactInfo.Phone?.Number,
            Mobile = result.ContactInfo.Phone?.Number,
            Country = result.Address.Country,
            PostalCode = result.Address.PostalCode.Value,
            State = result.Address.State,
            City = result.Address.City,
            Street = result.Address.Street,
            Number = result.Address.Number,
            Neighborhood = result.Address.Neighborhood,
            AdditionalInfo = result.Address.AdditionalInfo,
            Notes = result.Notes,
            Emails = result.ContactInfo.Emails.Select(e => e.Address).ToList(),
        };

        return response;
    }
}