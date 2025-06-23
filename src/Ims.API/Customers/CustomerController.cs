using AutoMapper;
using Ims.Application.Customers.Commands;
using Ims.Application.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ims.API.Customers;

[Authorize]
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
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand request)
    {
        var customerId = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetCustomer), new { id = customerId }, null);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand request)
    {
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        var result = await _mediator.Send(new GetCustomerQuery() { Id = id });
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var result = await _mediator.Send(new GetAllCustomersQuery());
        return Ok(result);
    }
}
