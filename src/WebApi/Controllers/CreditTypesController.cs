using Bank.Application.Features.CreditTypes.Commands.CreateCreditType;
using Bank.Application.Features.CreditTypes.Queries.GetCreditTypeList;
using Bank.Application.Features.CreditTypes.Queries.GetCreditTypeById;
using Bank.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Bank.Core.CrossCuttingConcerns.Exceptions.Types;

namespace Bank.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CreditTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Yeni kredi türü oluşturur
    /// </summary>
    /// <param name="command">Kredi türü bilgileri</param>
    /// <returns>Oluşturulan kredi türü</returns>
    [HttpPost]
    public async Task<ActionResult<CreateCreditTypeResponse>> Create([FromBody] CreateCreditTypeCommand command)
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
            return StatusCode(500, new { error = "Kredi türü oluşturulurken bir hata oluştu." });
        }
    }

    /// <summary>
    /// Kredi türlerini listeler
    /// </summary>
    /// <param name="category">Kredi kategorisi (opsiyonel)</param>
    /// <param name="isActive">Aktif durumu (opsiyonel)</param>
    /// <param name="page">Sayfa numarası</param>
    /// <param name="size">Sayfa boyutu</param>
    /// <returns>Kredi türleri listesi</returns>
    [HttpGet]
    public async Task<ActionResult<GetCreditTypeListResponse>> GetList(
        [FromQuery] string? category,
        [FromQuery] bool? isActive,
        [FromQuery] int page = 0,
        [FromQuery] int size = 10)
    {
        try
        {
            var query = new GetCreditTypeListQuery
            {
                Category = category,
                IsActive = isActive,
                Page = page,
                Size = size
            };

            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (Exception)
        {
            return StatusCode(500, new { error = "Kredi türleri listelenirken bir hata oluştu." });
        }
    }

    /// <summary>
    /// ID'ye göre kredi türü getirir
    /// </summary>
    /// <param name="id">Kredi türü ID'si</param>
    /// <returns>Kredi türü detayları</returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetCreditTypeByIdResponse>> GetById(Guid id)
    {
        try
        {
            var query = new GetCreditTypeByIdQuery { Id = id };
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { error = "Kredi türü getirilirken bir hata oluştu." });
        }
    }
}
