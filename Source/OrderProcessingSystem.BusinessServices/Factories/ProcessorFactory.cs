using OrderProcessingSystem.Common.Factories;
using OrderProcessingSystem.Common.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProcessingSystem.BusinessServices.Factories
{
    public sealed class ProcessorFactory : IProcessorFactory
    {
        public IPaymentProcessor CreateProcessor(RequestTypes requestTypes)
        {
            
        }
    }
}
