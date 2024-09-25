using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers
{

    [Route(ConstantHelper.Payments)]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet("/api/payments/success")]
        public async Task<IActionResult> SuccessReponse([FromQuery] PaymentReturnModel response)
        {
            return Ok(new { Message = "Payment Success", PaymentResponse = response });
        }

        [HttpGet("/api/payments/fail")]
        public async Task<IActionResult> FailResponse([FromQuery] PaymentReturnModel response)
        {
            return Ok(new { Message = "Payment Fail", PaymentResponse = response });
        }

        [HttpPost]
        public async Task<IActionResult> TestPayment(string description, int amount, string orderId)
        {
            var msg = await _paymentService.CreateQrCode( description , orderId, 2000);
            return Ok(msg);
        } 
    }
}
