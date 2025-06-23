using Ims.Application.Customers.DTO;
using MediatR;

namespace Ims.Application.Customers.Queries;

public record GetAllCustomersQuery() : IRequest<List<CustomerDto>>;