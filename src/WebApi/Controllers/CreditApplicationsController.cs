using Bank.Application.Features.CreditApplications.Commands.CreateCreditApplication;
using Bank.Application.Features.CreditApplications.Queries.GetCreditApplicationsByCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Bank.Core.Repositories;
using Bank.Domain.Entities;

namespace Bank.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditApplicationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CreditApplicationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Yeni kredi başvurusu oluşturur
    /// </summary>
    /// <param name="command">Kredi başvuru bilgileri</param>
    /// <returns>Oluşturulan kredi başvurusu</returns>
    [HttpPost]
    public async Task<ActionResult<CreateCreditApplicationResponse>> Create([FromBody] CreateCreditApplicationCommand command)
    {
        try
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { error = "Kredi başvurusu oluşturulurken bir hata oluştu." });
        }
    }

    /// <summary>
    /// ID'ye göre kredi başvurusu getirir
    /// </summary>
    /// <param name="id">Kredi başvuru ID'si</param>
    /// <returns>Kredi başvurusu detayları</returns>
    [HttpGet("{id:guid}")]
    public ActionResult<CreateCreditApplicationResponse> GetById(Guid id)
    {
        try
        {
            // TODO: GetCreditApplicationById query'si eklenecek
            return NotFound(new { error = "Bu endpoint henüz implement edilmedi." });
        }
        catch (Exception)
        {
            return StatusCode(500, new { error = "Kredi başvurusu getirilirken bir hata oluştu." });
        }
    }

    /// <summary>
    /// Müşteriye ait kredi başvurularını listeler
    /// </summary>
    /// <param name="customerId">Müşteri ID'si</param>
    /// <returns>Kredi başvuruları listesi (her durumda 200, boş liste olabilir)</returns>
    [HttpGet("customer/{customerId:guid}")]
    public async Task<ActionResult<GetCreditApplicationsByCustomerResponse>> GetByCustomer(Guid customerId)
    {
        try
        {
            var query = new GetCreditApplicationsByCustomerQuery { CustomerId = customerId };
            var response = await _mediator.Send(query);
            
            // Her durumda 200 OK döndür (boş liste olsa bile)
            return Ok(response);
        }
        catch (Exception)
        {
            // Hata durumunda bile boş liste döndür (200 OK)
            var emptyResponse = new GetCreditApplicationsByCustomerResponse(
                new List<CreditApplicationDto>(), 
                new Paginate<CreditApplication>(new List<CreditApplication>(), 0, 0, 0)
            );
            return Ok(emptyResponse);
        }
    }
}
