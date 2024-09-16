using Melior.InterviewQuestion.Services;
using Melior.InterviewQuestion.Types;
using Moq;

namespace Melior.InterviewQuestion.Tests
{

    // All class files will be tested in the following manner using Moq with verification on called methods to avoid coupling on other classes.
    // I have just written tests for the main file that has been refactored.
    // Writing tests for the other files is more straight forward, so I will demonsrtate one other.
    public class Tests
    {
        private Mock<IAccountService> _accountServiceMock;
        private Mock<IPaymentTypeStrategyFactory> _paymentTypeStrategyFactoryMock;
        private IPaymentService _paymentService;

        [SetUp]
        public void Setup()
        {
            _accountServiceMock = new Mock<IAccountService>();

            _paymentTypeStrategyFactoryMock = new Mock<IPaymentTypeStrategyFactory>();

            _paymentService = new PaymentService(_accountServiceMock.Object, _paymentTypeStrategyFactoryMock.Object);
        }

        [Test]
        public void NoAccount_NoPay()
        {
            MakePaymentResult makePaymentResult = _paymentService.MakePayment(new MakePaymentRequest());
            Assert.IsFalse(makePaymentResult.Success);
        }

        [Test]
        public void ValidAccountAndAmount_PaymentFail_NoSuccessAndNoUpdate()
        {
            const string AccountNumber = "12345";

            Account account = new()
            {
                AccountNumber = AccountNumber,
                Balance = 10
            };


            Mock<IPaymentTypeStrategy> paymentTypeStrategyMock = new Mock<IPaymentTypeStrategy>();
            paymentTypeStrategyMock.Setup(x => x.Pay(account, It.IsAny<decimal>())).Returns(new MakePaymentResult { Success = false });

            _paymentTypeStrategyFactoryMock.Setup(x => x.Get(It.IsAny<PaymentScheme>())).Returns(paymentTypeStrategyMock.Object);

            _accountServiceMock.Setup(x => x.Get(AccountNumber)).Returns(account);


            MakePaymentResult makePaymentResult = _paymentService.MakePayment(new MakePaymentRequest { Amount = 3, PaymentScheme = PaymentScheme.FasterPayments, DebtorAccountNumber = AccountNumber });
            Assert.IsFalse(makePaymentResult.Success);

            Assert.That(account.Balance, Is.EqualTo(10));

            _accountServiceMock.Verify(x => x.Get(AccountNumber), Times.Once);
            _accountServiceMock.Verify(x => x.Update(account), Times.Never);
        }

        [Test]
        public void ValidAccountAndAmount_SuccessAndUpdate()
        {
            const string AccountNumber = "12345";

            Account account = new Account
            {
                AccountNumber = AccountNumber,
                Balance = 10
            };


            Mock<IPaymentTypeStrategy> paymentTypeStrategyMock = new Mock<IPaymentTypeStrategy>();
            paymentTypeStrategyMock.Setup(x => x.Pay(account, It.IsAny<decimal>())).Returns(new MakePaymentResult { Success = true });
            
            _paymentTypeStrategyFactoryMock.Setup(x => x.Get(It.IsAny<PaymentScheme>())).Returns(paymentTypeStrategyMock.Object);
            
            _accountServiceMock.Setup(x => x.Get(AccountNumber)).Returns(account);


            MakePaymentResult makePaymentResult = _paymentService.MakePayment(new MakePaymentRequest { Amount = 3, PaymentScheme = PaymentScheme.FasterPayments, DebtorAccountNumber = AccountNumber });
            Assert.IsTrue(makePaymentResult.Success);

            Assert.That(account.Balance, Is.EqualTo(7));

            _accountServiceMock.Verify(x => x.Get(AccountNumber), Times.Once);
            _accountServiceMock.Verify(x => x.Update(account), Times.Once);
        }
    }
}