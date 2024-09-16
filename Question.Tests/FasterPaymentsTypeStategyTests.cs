using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Tests
{
    public class FasterPaymentsTypeStategyTests
    {
        private IPaymentTypeStrategy _fasterPaymentsTypeStrategy;

        [SetUp]
        public void Setup()
        {
            _fasterPaymentsTypeStrategy = new FasterPaymentsTypeStrategy();
        }

        [Test]
        public void NullAccount_NoSuccess()
        {
            MakePaymentResult makePaymentResult = _fasterPaymentsTypeStrategy.Pay(null, 3);
            Assert.That(makePaymentResult.Success, Is.False);
        }

        [Test]
        public void ValidAccount_NofasterPaymentsFlag_NoSuccess()
        {
            Account account = new Account();

            MakePaymentResult makePaymentResult = _fasterPaymentsTypeStrategy.Pay(account, 3);
            Assert.That(makePaymentResult.Success, Is.False);
        }

        [Test]
        public void ValidAccountAndFasterPaymentsFlag_BalanceTooLow_NoSuccess()
        {
            Account account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Balance = 0 };

            MakePaymentResult makePaymentResult = _fasterPaymentsTypeStrategy.Pay(account, 3);
            Assert.That(makePaymentResult.Success, Is.False);
        }

        [Test]
        public void ValidAccountAndChapsFlagAndBalance_Success()
        {
            Account account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Balance = 3 };

            MakePaymentResult makePaymentResult = _fasterPaymentsTypeStrategy.Pay(account, 3);
            Assert.That(makePaymentResult.Success, Is.True);
        }
    }
}
