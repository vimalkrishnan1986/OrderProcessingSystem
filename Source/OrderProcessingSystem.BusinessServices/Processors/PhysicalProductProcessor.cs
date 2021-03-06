﻿using System.Collections.Generic;
using System.Threading.Tasks;
using OrderProcessingSystem.Common.Components;
using OrderProcessingSystem.Common.Logging;
using OrderProcessingSystem.Common.Model;

namespace OrderProcessingSystem.BusinessServices.Processors
{
    public sealed class PhysicalProductProcessor : ProcessorBase
    {
        public PhysicalProductProcessor(ILogger logger, IEnumerable<IComponent> components)
            : base(logger, components)
        {

        }
        protected override Task ProcessPaymentAsync(PaymentRequest paymentRequest)
        {
            _logger.Log("Generating packing slip");
            return Task.CompletedTask;
        }
    }
}
