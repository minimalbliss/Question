using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services
{
    public interface IAccountService
    {
        Account Get(string accountNumber);

        void Update(Account account);
    }
}
