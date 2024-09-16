using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountService _accountService;

        private readonly IPaymentTypeStrategyFactory _paymentTypeStrategyFactory;

        public PaymentService(IAccountService accountService, IPaymentTypeStrategyFactory paymentTypeStrategyFactory)
        {
            _accountService = accountService;
            _paymentTypeStrategyFactory = paymentTypeStrategyFactory;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            Account account = _accountService.Get(request.DebtorAccountNumber);
            if (account == null)
            {
                // could log the error and return false
                // could log the error and throw (business/technical decision)
                return new MakePaymentResult { Success = false };
            }

            IPaymentTypeStrategy paymentTypeStrategy = _paymentTypeStrategyFactory.Get(request.PaymentScheme);

            MakePaymentResult result = paymentTypeStrategy.Pay(account, request.Amount);
           
            if  (result.Success)
            {
                account.Balance -= request.Amount;
                _accountService.Update(account);
            }

            return result;
        }
    }
}
