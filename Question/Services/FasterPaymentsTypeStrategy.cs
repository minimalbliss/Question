﻿using Melior.InterviewQuestion.Types;

public class FasterPaymentsTypeStrategy : IPaymentTypeStrategy
{
    public MakePaymentResult Pay(Account account, decimal amount)
    {
        // I may be missing something but the original code had no way of being a success
        MakePaymentResult result = new MakePaymentResult { Success = true };

        if (account == null)
        {
            result.Success = false;
        }
        else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
        {
            result.Success = false;
        }
        else if (account.Balance < amount)
        {
            result.Success = false;
        }

        return result;
    }
}