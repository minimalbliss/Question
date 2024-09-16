using Melior.InterviewQuestion.Services;

namespace Melior.InterviewQuestion.Tests
{
    public class PaymentTypeStrategyFactoryTests
    {
        private IPaymentTypeStrategyFactory _paymentTypeStrategyFactory;

        [SetUp]
        public void Setup()
        {
            _paymentTypeStrategyFactory = new PaymentTypeStrategyFactory();
        }

        [Test]
        public void FasterPaymentsScheme_ReturnesFasterPaymentsSchemeStrategy()
        {
            IPaymentTypeStrategy paymentTypeStrategy = _paymentTypeStrategyFactory.Get(Types.PaymentScheme.FasterPayments);
            Assert.IsInstanceOf(typeof(FasterPaymentsTypeStrategy), paymentTypeStrategy);
        }

        [Test]
        public void BacsPaymentsScheme_ReturnsBacsPaymentsSchemeStrategy()
        {
            IPaymentTypeStrategy paymentTypeStrategy = _paymentTypeStrategyFactory.Get(Types.PaymentScheme.Bacs);
            Assert.IsInstanceOf(typeof(BacsPaymentsTypeStrategy), paymentTypeStrategy);
        }

        [Test]
        public void ChapsPaymentsScheme_ReturnsChapsPaymentsSchemeStrategy()
        {
            IPaymentTypeStrategy paymentTypeStrategy = _paymentTypeStrategyFactory.Get(Types.PaymentScheme.Chaps);
            Assert.IsInstanceOf(typeof(ChapsPaymentsTypeStrategy), paymentTypeStrategy);
        }
    }
}
