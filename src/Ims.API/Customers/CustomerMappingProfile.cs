using AutoMapper;
using Ims.API.Customers.Models.Requests;
using Ims.Application.Customers.Commands;

namespace Ims.API.Customers;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CreateCustomerRequest, CreateCustomerCommand>();
    }
}
