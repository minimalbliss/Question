using Melior.InterviewQuestion.Types;

public class BacsPaymentsTypeStrategy : IPaymentTypeStrategy
{
    public MakePaymentResult Pay(Account account, decimal amount)
    {
        // I may be missing something but the original code had no way of being a success
        MakePaymentResult result = new MakePaymentResult { Success = true };

        if (account == null)
        {
            result.Success = false;
        }
        else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
        {
            result.Success = false;
        }

        return result;
    }
}
