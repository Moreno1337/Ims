using Ims.Application.Customers.DTO;
using MediatR;

namespace Ims.Application.Customers.Queries;

public record GetCustomerQuery() : IRequest<CustomerDto>
{
    public int Id { get; set; }
}