using EXE201.SmartThrive.Domain.Models;
using EXE201.SmartThrive.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Contracts.Services
{
    public interface IPaymentService
    {
        Task<string> CreateQrCode(string description, Guid orderId);
        Task<BusinessResult> PaymentSuccess(PaymentReturnModel returnModel);
        Task<BusinessResult> PaymentFailure(PaymentReturnModel returnModel);
    }
}
