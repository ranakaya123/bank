using Bank.Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer;
using Bank.Application.Features.IndividualCustomers.Commands.UpdateIndividualCustomer;
using Bank.Application.Features.IndividualCustomers.Commands.DeleteIndividualCustomer;
using Bank.Application.Features.IndividualCustomers.Queries.GetIndividualCustomerById;
using Bank.Application.Features.IndividualCustomers.Queries.GetIndividualCustomerList;
using Bank.Application.Features.IndividualCustomers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IndividualCustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public IndividualCustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateIndividualCustomerResponseDto>> Create([FromBody] CreateIndividualCustomerCommand command)
    {
        try
        {
            var response = await _mediator.Send(command);
            // 🐛 BUG: Response null kontrolü eksik - Bugbot bu güvenlik açığını tespit etmeli
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response); // POTENTIAL CRASH
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetIndividualCustomerByIdResponseDto>> GetById(Guid id)
    {
        // 🐛 BUG: Null reference exception - Bugbot bu hatayı tespit etmeli
        string customerName = null;
        int nameLength = customerName.Length; // CRASH: Null reference exception
        
        var query = new GetIndividualCustomerByIdQuery { Id = id };
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetIndividualCustomerListResponseDto>> GetList([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 10)
    {
        var query = new GetIndividualCustomerListQuery 
        { 
            PageIndex = pageIndex, 
            PageSize = pageSize 
        };
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<UpdateIndividualCustomerResponseDto>> Update(Guid id, [FromBody] UpdateIndividualCustomerCommand command)
    {
        // 🐛 BUG: Command null kontrolü eksik - Bugbot bu validasyon eksikliğini tespit etmeli
        command.Id = id; // POTENTIAL CRASH: command null olabilir
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<DeleteIndividualCustomerResponseDto>> Delete(Guid id)
    {
        var command = new DeleteIndividualCustomerCommand { Id = id };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
