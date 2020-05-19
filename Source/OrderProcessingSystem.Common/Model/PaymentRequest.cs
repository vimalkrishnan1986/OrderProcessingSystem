using System;
using OrderProcessingSystem.Common.Model.Enums;

namespace OrderProcessingSystem.Common.Model
{
    public class PaymentRequest
    {
        public RequestTypes RequestType { get; set; }
        public Decimal Amount { get; set; }
    }
}
