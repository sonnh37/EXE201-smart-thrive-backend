using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Models;
using EXE201.SmartThrive.Domain.Models.Results;
using Microsoft.Extensions.Configuration;
using Net.payOS;
using Net.payOS.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PayOS payos;
        private readonly IConfiguration _configuration;
        protected readonly IUnitOfWork _unitOfWork;

        public PaymentService(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this._configuration = configuration;
            this._unitOfWork = unitOfWork;
            payos = new PayOS(PayOsSettingModel.Instance.clientId, PayOsSettingModel.Instance.apiKey, PayOsSettingModel.Instance.checkSumKey);
        }
        private static string CreateHmacSha256(string data, string key)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256(System.Text.Encoding.UTF8.GetBytes(key)))
            {
                var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(data));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        public async Task<string> CreateQrCode(string description, Guid orderId )
        {
            int amount = 0;
            // Map for items detail
            var courseFromPackage = await _unitOfWork.OrderRepository.GetItemsFromOrder(orderId);
            List<ItemData> data = new List<ItemData>();
            foreach(var items in courseFromPackage.Package.PackageXCourses)
            {
                data.Add(new ItemData(items.Course.CourseName, 1, (int)items.Course.Price));
                amount += (int)items.Course.Price;
            }
            // Init data for request
            var domain = _configuration.GetSection("Domain").Value;
            var successReturnUrl = domain + "/payments/success?orderId=" +orderId;
            var failReturnUrl = domain + "/payments/fail?orderId=" + orderId;
            var orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
            // Create signature
            var signatureData = $"amount={amount}&cancelUrl={failReturnUrl}&description={description}&orderCode={orderCode}&returnUrl={successReturnUrl}";
            var signature = CreateHmacSha256(signatureData, PayOsSettingModel.Instance.checkSumKey);
            
            // Create data to request payment
            var paymentLinkRequest = new PaymentData(
                    orderCode: orderCode,
                    amount: amount,
                    description,
                    items: data,
                    returnUrl: successReturnUrl,
                    cancelUrl: failReturnUrl,
                    expiredAt: (int)(DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds()),
                    signature: signature
                ); 
            // Send the request to PayOs
            var response = await payos.createPaymentLink(paymentLinkRequest);
            return response.checkoutUrl;
        }
    }
}
