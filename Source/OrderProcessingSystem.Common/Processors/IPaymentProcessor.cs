using OrderProcessingSystem.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingSystem.Common.Factories
{
    public interface IPaymentProcessor
    {
        Task ProcessAsync(PaymentRequest paymentRequest);
    }
}
