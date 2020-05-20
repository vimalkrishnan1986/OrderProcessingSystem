using System;
using OrderProcessingSystem.BusinessServices.Processors;
using OrderProcessingSystem.Common.Components;
using OrderProcessingSystem.Common.Factories;
using OrderProcessingSystem.Common.Logging;
using OrderProcessingSystem.Common.Model.Enums;

namespace OrderProcessingSystem.BusinessServices.Factories
{
    public sealed class ProcessorFactory : IProcessorFactory
    {
        private readonly ILogger _logger;
        private readonly IComponentSupplier _componentSupplier;

        public ProcessorFactory(ILogger logger, IComponentSupplier componentSupplier)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _componentSupplier = componentSupplier ?? throw new ArgumentNullException(nameof(componentSupplier));
        }
        public IPaymentProcessor CreateProcessor(RequestTypes requestTypes)
        {
            IPaymentProcessor paymentProcessor = null;
            switch (requestTypes)

            {
                case RequestTypes.Books:
                    {
                        paymentProcessor = new BookProcessor(_logger,_componentSupplier.GetComponents());
                        break;
                    }

                case RequestTypes.MemberShips:
                    {
                        paymentProcessor = new MemberShipProcessor(_logger, _componentSupplier.GetComponents());
                        break;
                    }

                case RequestTypes.UpgradeMemberShip:
                    {
                        paymentProcessor = new UpgradeMemberShipProcesor(_logger, _componentSupplier.GetComponents());
                        break;
                    }

                case RequestTypes.PhysicalProduct:
                    {
                        paymentProcessor = new PhysicalProductProcessor(_logger, _componentSupplier.GetComponents());
                        break;
                    }
            }


            return paymentProcessor;
        }
    }
}
