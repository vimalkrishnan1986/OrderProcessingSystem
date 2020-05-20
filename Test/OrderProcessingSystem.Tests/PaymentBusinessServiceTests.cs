using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderProcessingSystem.BusinessServices;
using OrderProcessingSystem.BusinessServices.Factories;
using OrderProcessingSystem.Common.Business;
using OrderProcessingSystem.Common.Components;
using OrderProcessingSystem.Common.Logging;
using OrderProcessingSystem.Common.Model;
using OrderProcessingSystem.Common.Model.Enums;

namespace OrderProcessingSystem.Tests
{
    [TestClass]
    public class PaymentBusinessServiceTests
    {
        private IPaymentService paymentService;
        private Mock<ILogger> _mockLogger = new Mock<ILogger>();
        Mock<IComponent> _mockPackingSlip = new Mock<IComponent>();
        Mock<IComponent> _mockEmail = new Mock<IComponent>();
        private Mock<IComponentSupplier> _mockComponentSuppllier = new Mock<IComponentSupplier>();
        const decimal amount = 100;

        [TestInitialize]
        public void TestInitilize()
        {
            _mockLogger.Setup(p => p.Log(It.IsAny<string>()));
            _mockPackingSlip.Setup(p => p.Process()).Returns(Task.CompletedTask);
            _mockEmail.Setup(p => p.Process()).Returns(Task.CompletedTask);
            paymentService = new PaymentBusinessService(new ProcessorFactory(_mockLogger.Object, _mockComponentSuppllier.Object));
        }


        [TestMethod]
        public async Task Order_PhysicalProduct()
        {
            // Assemble
            var request = GetPaymentRequest(RequestTypes.PhysicalProduct);

            _mockComponentSuppllier.Setup(p => p.GetComponents()).Returns(new List<IComponent>
             {_mockPackingSlip.Object });
            paymentService.Should().NotBeNull();

            // Act
            await paymentService.ProcessPaymentAsync(request);

            // Assert
            _mockLogger.Verify(p => p.Log("Generating packing slip"), Times.Exactly(1));
            _mockPackingSlip.Verify(p => p.Process(), Times.Exactly(1));
        }


        [TestMethod]
        public async Task Order_MemberShips()
        {
            _mockComponentSuppllier.Setup(p => p.GetComponents()).Returns(new List<IComponent>
             {_mockEmail.Object });
            // Assemble
            var request = GetPaymentRequest(RequestTypes.MemberShips);
            paymentService.Should().NotBeNull();

            // Act
            await paymentService.ProcessPaymentAsync(request);

            // Assert
            _mockLogger.Verify(p => p.Log("Activating Membership"), Times.Exactly(1));
            _mockEmail.Verify(p => p.Process(), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Order_UpgradeMemberShips()
        {
            // Assemble
            _mockComponentSuppllier.Setup(p => p.GetComponents()).Returns(new List<IComponent>
             {_mockEmail.Object });
            var request = GetPaymentRequest(RequestTypes.UpgradeMemberShip);
            paymentService.Should().NotBeNull();

            // Act
            await paymentService.ProcessPaymentAsync(request);

            // Assert
            _mockLogger.Verify(p => p.Log("Upgrading Membership"), Times.Exactly(1));
            _mockEmail.Verify(p => p.Process(), Times.Exactly(1));
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
