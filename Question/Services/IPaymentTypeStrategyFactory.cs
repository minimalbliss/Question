using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services
{
    public interface IPaymentTypeStrategyFactory
    {
        IPaymentTypeStrategy Get(PaymentScheme paymentScheme);
    }
}