using System.Collections.Generic;
using System.Threading.Tasks;
using OrderProcessingSystem.Common.Components;
using OrderProcessingSystem.Common.Logging;
using OrderProcessingSystem.Common.Model;

namespace OrderProcessingSystem.BusinessServices.Processors
{
    public sealed class BookProcessor : ProcessorBase
    {

        public BookProcessor(ILogger logger, IEnumerable<IComponent> components)
            : base(logger, components)
        {

        }
        protected override Task ProcessPaymentAsync(PaymentRequest paymentRequest)
        {
            _logger.Log("Creating duplicate packing slip");
            return Task.CompletedTask;
        }
    }
}
