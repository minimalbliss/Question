using Melior.InterviewQuestion.Services;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Tests
{
    public class BacsPaymentsTypeStrategyTests
    {
        private IPaymentTypeStrategy _bacsPaymentTypeStrategy;

        [SetUp]
        public void Setup()
        {
            _bacsPaymentTypeStrategy = new BacsPaymentsTypeStrategy();
        }

        [Test]
        public void NullAccount_NoSuccess()
        {
            MakePaymentResult makePaymentResult = _bacsPaymentTypeStrategy.Pay(null, 3);
            Assert.That(makePaymentResult.Success, Is.False);
        }

        [Test]
        public void ValidAccount_NoBacsFlag_NoSuccess()
        {
            Account account = new Account();

            MakePaymentResult makePaymentResult = _bacsPaymentTypeStrategy.Pay(account, 3);
            Assert.That(makePaymentResult.Success, Is.False);
        }

        [Test]
        public void ValidAccountAndBacsFlag_Success()
        {
            Account account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs};

            MakePaymentResult makePaymentResult = _bacsPaymentTypeStrategy.Pay(account, 3);
            Assert.That(makePaymentResult.Success, Is.True);
        }
    }
}
