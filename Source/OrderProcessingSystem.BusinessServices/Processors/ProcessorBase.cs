using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderProcessingSystem.Common.Components;
using OrderProcessingSystem.Common.Factories;
using OrderProcessingSystem.Common.Logging;
using OrderProcessingSystem.Common.Model;

namespace OrderProcessingSystem.BusinessServices.Processors
{
    public abstract class ProcessorBase : IPaymentProcessor
    {
        private IEnumerable<IComponent> _components;
        protected abstract Task ProcessPaymentAsync(PaymentRequest paymentRequest);
        protected ILogger _logger;
        protected ProcessorBase(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected ProcessorBase(ILogger logger, IEnumerable<IComponent> components)
            : this(logger)
        {
            _components = components ?? throw new ArgumentNullException(nameof(components));
        }

        public async Task ProcessAsync(PaymentRequest paymentRequest)
        {
            Console.WriteLine($"Request has been recieve for type {paymentRequest.RequestType}");

            await ProcessPaymentAsync(paymentRequest)
                .ConfigureAwait(false);

            await ProcessComponents()
                .ConfigureAwait(false);
        }


        private Task ProcessComponents()
        {
            if (_components == null)
            {
                return Task.CompletedTask;
            }

            List<Task> componentTasks = new List<Task>();
            foreach (var component in _components)
            {
                componentTasks.Add(component.Process());
            }

            return Task.WhenAll(componentTasks);
        }
    }
}
