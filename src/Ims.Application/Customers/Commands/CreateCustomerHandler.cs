using Ims.Application.Customers;
using Ims.Application.Customers.Commands;
using Ims.Domain.Customers;
using MediatR;

namespace IMS.Application.Customers.Commands;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, int>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateCustomerCommand request, CancellationToken ct)
    {
        var customer = Customer.Create(
            request.Type,
            request.CPF,
            request.Name,
            request.BirthDate,
            request.CNPJ,
            request.CorporateName,
            request.TradeName,
            request.StateRegistration,
            request.BillingTerm,
            request.Interest,
            request.Fine,
            request.Phone,
            request.Mobile,
            request.Country,
            request.PostalCode,
            request.State,
            request.City,
            request.Street,
            request.Number,
            request.Neighborhood,
            request.AdditionalInfo,
            request.Notes,
            request.Emails
        );

        await _repository.AddAsync(customer);
        return customer.Id;
    }
}
