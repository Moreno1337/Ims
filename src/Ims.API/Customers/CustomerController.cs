using AutoMapper;
using Ims.API.Customers.Models.Requests;
using Ims.Application.Customers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ims.API.Customers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CustomerController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
    {
        var command = _mapper.Map<CreateCustomerCommand>(request);
        var customerId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCustomer), new { id = customerId }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers(int id)
    {
        throw new NotImplementedException();
    }
}
