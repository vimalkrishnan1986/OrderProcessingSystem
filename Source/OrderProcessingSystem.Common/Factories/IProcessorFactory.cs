using OrderProcessingSystem.Common.Model.Enums;

namespace OrderProcessingSystem.Common.Factories
{
    public interface IProcessorFactory
    {
        IPaymentProcessor CreateProcessor(RequestTypes requestTypes);
    }
}
