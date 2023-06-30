using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Services;
using TecFinance_Backend.API.Simulation.Resources;

namespace TecFinance_Backend.API.Simulation.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/offers/{offerId}/payments")]
[Produces(MediaTypeNames.Application.Json)]
public class OfferPaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IMapper _mapper;
    
    public OfferPaymentsController(IPaymentService paymentService, IMapper mapper)
    {
        _paymentService = paymentService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Payments for Given Offer",
        Description = "Get existing Payments associated with the specified Offer",
        OperationId = "GetOfferPayments",
        Tags = new []{"Payments"})]
    public async Task<IEnumerable<PaymentResource>> GetAllByOfferId(int offerId)
    {
        var payments = await _paymentService.ListByOfferIdAsync(offerId);
        var resources = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(payments);
        return resources;
    }
}