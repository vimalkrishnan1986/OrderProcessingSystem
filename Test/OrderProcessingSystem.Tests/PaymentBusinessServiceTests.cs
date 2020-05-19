using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProcessingSystem.BusinessServices;
using OrderProcessingSystem.BusinessServices.Factories;
using OrderProcessingSystem.Common.Business;
using OrderProcessingSystem.Common.Model;
using OrderProcessingSystem.Common.Model.Enums;
using System.Threading.Tasks;

namespace OrderProcessingSystem.Tests
{
    [TestClass]
    public class PaymentBusinessServiceTests
    {
        private IPaymentService paymentService;
        const decimal amount = 100;

        [TestInitialize]
        public void TestInitilize()
        {
            paymentService = new PaymentBusinessService(new ProcessorFactory());
        }


        [TestMethod]
        public async Task Order_PhysicalProduct()
        {
            // Assemble
            var request = GetPaymentRequest(RequestTypes.PhysicalProduct);
            paymentService.Should().NotBeNull();

            // Act
            await paymentService.ProcessPaymentAsync(request);

            // Assert
        }


        [TestMethod]
        public async Task Order_MemberShips()
        {
            // Assemble
            var request = GetPaymentRequest(RequestTypes.PhysicalProduct);
            paymentService.Should().NotBeNull();

            // Act
            await paymentService.ProcessPaymentAsync(request);

            // Assert
        }

        public async Task Order_UpgradeMemberShips()
        {
            // Assemble
            var request = GetPaymentRequest(RequestTypes.PhysicalProduct);
            paymentService.Should().NotBeNull();

            // Act
            await paymentService.ProcessPaymentAsync(request);

            // Assert
        }

        private PaymentRequest GetPaymentRequest(RequestTypes requestTypes)
        {
            return new PaymentRequest
            {
                Amount = amount,
                RequestType = requestTypes
            };
        }
    }
}
