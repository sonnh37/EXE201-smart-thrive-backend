using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Authorization;
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
            await _paymentService.PaymentSuccess(response);
            return Redirect("http://localhost:3000/payment/thanks");
        }

        [HttpGet("/api/payments/fail")]
        public async Task<IActionResult> FailResponse([FromQuery] PaymentReturnModel response)
        {
            await _paymentService.PaymentFailure(response);
            return Redirect("http://localhost:3000/payment/fail");
        }

        [HttpPost]
        public async Task<IActionResult> TestPayment(string description, Guid orderId)
        {
            var msg = await _paymentService.CreateQrCode(description, orderId);
            return Ok(msg);
        }
    }
}
