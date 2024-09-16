using Melior.InterviewQuestion.Services;
using Melior.InterviewQuestion.Types;
using Moq;

namespace Melior.InterviewQuestion.Tests
{
    public  class AccountServiceTests
    {
        // Basic test on this showing the use of a facade to bypass the configuration
        // other tests can be written to show the difference in the account service being a backup or other type
        [Test]
        public void Whatever()
        {
            AccountService accountService = new AccountService(new DummyConfiguration());
            Account account = accountService.Get("1234");
            Assert.IsNull(account.AccountNumber);
        }
    }
}
