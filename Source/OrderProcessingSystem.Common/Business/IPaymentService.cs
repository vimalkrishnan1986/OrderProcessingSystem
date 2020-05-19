using System.Threading.Tasks;
using OrderProcessingSystem.Common.Model;

namespace OrderProcessingSystem.Common.Business
{
    public interface IPaymentService
    {
        Task ProcessPaymentAsync(PaymentRequest paymentRequest);
    }
}
