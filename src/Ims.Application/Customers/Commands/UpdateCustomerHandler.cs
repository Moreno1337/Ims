using Ims.Application.Customers;
using Ims.Application.Customers.Commands;
using Ims.Domain.Customers;
using Ims.Domain.Customers.ValueObjects;
using Ims.Domain.Shared.ValueObjects;
using MediatR;

namespace IMS.Application.Customers.Commands;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand>
{
    private readonly ICustomerRepository _repository;

    public UpdateCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCustomerCommand request, CancellationToken ct)
    {
        CustomerType type;
        bool typeIsOk = Enum.TryParse<CustomerType>(request.Type, ignoreCase: true, out type);

        if (!typeIsOk)
            throw new ArgumentException("Invalid customer type", nameof(request.Type));

        PersonInfo? personInfo = null;
        CompanyInfo? companyInfo = null;

        if (type == CustomerType.NaturalPerson)
        {
            personInfo = PersonInfo.Create(
                request.CPF,
                request.Name,
                request.BirthDate
            );
        }

        if (type == CustomerType.LegalEntity)
        {
            companyInfo = CompanyInfo.Create(
                request.CNPJ,
                request.CorporateName,
                request.TradeName,
                request.StateRegistration,
                request.BillingTerm,
                request.Interest,
                request.Fine
            );
        }

        var address = Address.Create(
            request.Country,
            request.PostalCode,
            request.State,
            request.City,
            request.Street,
            request.Number,
            request.Neighborhood,
            request.AdditionalInfo
        );

        Mobile? mobile = null;
        Phone? phone = null;

        if (!string.IsNullOrEmpty(request.Mobile))
            mobile = Mobile.Create(request.Mobile);

        if (!string.IsNullOrEmpty(request.Phone))
            phone = Phone.Create(request.Phone);

        var contactInfo = ContactInfo.Create(
            phone,
            mobile,
            request.Emails
        );

        var customer = Customer.Create(
            request.Id,
            type,
            personInfo,
            companyInfo,
            address,
            contactInfo,
            request.Notes
        );

        await _repository.UpdateAsync(customer);
    }
}