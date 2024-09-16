using Melior.InterviewQuestion.Services;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Tests
{
    public  class ChapsPaymentsTypeStrategyTests
    {
        private IPaymentTypeStrategy _chapsPaymentTypeStrategy;

        [SetUp]
        public void Setup()
        {
            _chapsPaymentTypeStrategy = new ChapsPaymentsTypeStrategy();
        }

        [Test]
        public void NullAccount_NoSuccess()
        {
            MakePaymentResult makePaymentResult = _chapsPaymentTypeStrategy.Pay(null, 3);
            Assert.That(makePaymentResult.Success, Is.False);
        }

        [Test]
        public void ValidAccount_NoChapsFlag_NoSuccess()
        {
            Account account = new Account();

            MakePaymentResult makePaymentResult = _chapsPaymentTypeStrategy.Pay(account, 3);
            Assert.That(makePaymentResult.Success, Is.False);
        }

        [Test]
        public void ValidAccountAndChapsFlagNotLive_NoSuccess()
        {
            Account account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Status = AccountStatus.Disabled };

            MakePaymentResult makePaymentResult = _chapsPaymentTypeStrategy.Pay(account, 3);
            Assert.That(makePaymentResult.Success, Is.False);
        }

        [Test]
        public void ValidAccountAndChapsFlagAndLive_Success()
        {
            Account account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Status = AccountStatus.Live };

            MakePaymentResult makePaymentResult = _chapsPaymentTypeStrategy.Pay(account, 3);
            Assert.That(makePaymentResult.Success, Is.True);
        }
    }
}
