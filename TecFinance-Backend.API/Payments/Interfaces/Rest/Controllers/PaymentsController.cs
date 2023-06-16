using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TecFinance_Backend.API.Payments.Domain.Models;
using TecFinance_Backend.API.Payments.Domain.Services;
using TecFinance_Backend.API.Payments.Resources;
using TecFinance_Backend.API.Shared.Extensions;

namespace TecFinance_Backend.API.Payments.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IMapper _mapper;
    
    public PaymentsController(IPaymentService paymentService, IMapper mapper)
    {
        _paymentService = paymentService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PaymentResource>> GetAllAsync()
    {
        var payments = await _paymentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(payments);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePaymentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var payment = _mapper.Map<SavePaymentResource, Payment>(resource);
        
        var result = await _paymentService.SaveAsync(payment);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

        return Created(nameof(PostAsync), paymentResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _paymentService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);
        return Ok(paymentResource);
    }
}