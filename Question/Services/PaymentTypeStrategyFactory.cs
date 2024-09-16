using Melior.InterviewQuestion.Types;
using System;

namespace Melior.InterviewQuestion.Services
{
    public class PaymentTypeStrategyFactory : IPaymentTypeStrategyFactory
    {
        public IPaymentTypeStrategy Get(PaymentScheme paymentScheme)
        {
            switch (paymentScheme)
            {
                case PaymentScheme.FasterPayments:
                    return new FasterPaymentsTypeStrategy();

                case PaymentScheme.Bacs:
                    return new BacsPaymentsTypeStrategy();

                case PaymentScheme.Chaps:
                    return new ChapsPaymentsTypeStrategy();

                default: throw new ArgumentException("Invalid payment scheme", nameof(paymentScheme));
            }
        }
    }
}