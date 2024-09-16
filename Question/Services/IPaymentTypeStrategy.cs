using Melior.InterviewQuestion.Types;

public interface IPaymentTypeStrategy
{
    MakePaymentResult Pay(Account account, decimal amount);
}
