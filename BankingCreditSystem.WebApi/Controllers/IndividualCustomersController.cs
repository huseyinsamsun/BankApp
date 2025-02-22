using MediatR;
using Microsoft.AspNetCore.Mvc;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Update;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetList;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using System.Net.Mime;

namespace BankingCreditSystem.WebApi.Controllers;

/// <summary>
/// Bireysel müşteri işlemleri için API endpoint'leri
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class IndividualCustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public IndividualCustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Belirtilen ID'ye sahip bireysel müşteriyi getirir
    /// </summary>
    /// <param name="id">Müşteri ID'si</param>
    /// <returns>Bireysel müşteri detayları</returns>
    /// <response code="200">Müşteri başarıyla getirildi</response>
    /// <response code="404">Müşteri bulunamadı</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetIndividualCustomerByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Bireysel müşteri listesini sayfalı şekilde getirir
    /// </summary>
    /// <param name="query">Sayfalama parametreleri</param>
    /// <returns>Sayfalanmış müşteri listesi</returns>
    /// <response code="200">Müşteri listesi başarıyla getirildi</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList([FromQuery] GetIndividualCustomerListQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Yeni bir bireysel müşteri oluşturur
    /// </summary>
    /// <param name="request">Müşteri bilgileri</param>
    /// <returns>Oluşturulan müşteri bilgileri</returns>
    /// <response code="201">Müşteri başarıyla oluşturuldu</response>
    /// <response code="400">Geçersiz müşteri bilgileri</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateIndividualCustomerRequest request)
    {
        var command = new CreateIndividualCustomerCommand(request);
        var result = await _mediator.Send(command);
        return Created($"api/individualcustomers/{result.Id}", result);
    }

    /// <summary>
    /// Mevcut bir bireysel müşteriyi günceller
    /// </summary>
    /// <param name="id">Güncellenecek müşteri ID'si</param>
    /// <param name="request">Güncellenecek müşteri bilgileri</param>
    /// <returns>Güncellenmiş müşteri bilgileri</returns>
    /// <response code="200">Müşteri başarıyla güncellendi</response>
    /// <response code="400">Geçersiz müşteri bilgileri</response>
    /// <response code="404">Müşteri bulunamadı</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateIndividualCustomerRequest request)
    {
        var command = new UpdateIndividualCustomerCommand(id, request);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
} 