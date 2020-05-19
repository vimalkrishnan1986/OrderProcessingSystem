using System;
using System.Threading.Tasks;
using OrderProcessingSystem.Common.Factories;
using OrderProcessingSystem.Common.Model;
using OrderProcessingSystem.Common.Business;

namespace OrderProcessingSystem.BusinessServices
{
    public class PaymentBusinessService : IPaymentService
    {
        private readonly IProcessorFactory _processorFactory;
        public PaymentBusinessService(IProcessorFactory processorFactory)
        {
            _processorFactory = processorFactory ?? throw new ArgumentNullException(nameof(processorFactory));
        }
        public Task ProcessPaymentAsync(PaymentRequest paymentRequest)
        {
            var processor = _processorFactory.CreateProcessor(paymentRequest.RequestType);
            if (processor == null)
            {
                throw new NotImplementedException($"Processor is not found for {paymentRequest.RequestType}");
            }

            return processor.ProcessAsync(paymentRequest);
        }
    }
}
