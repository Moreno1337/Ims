using Ims.Domain.Customers;

namespace Ims.Application.Customers;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
}
