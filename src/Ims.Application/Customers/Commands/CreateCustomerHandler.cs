using Ims.Application.Customers.Commands;
using MediatR;

namespace IMS.Application.Customers.Commands;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, int>
{
    public async Task<int> Handle(CreateCustomerCommand request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
