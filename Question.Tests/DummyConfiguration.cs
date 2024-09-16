using Melior.InterviewQuestion.Services;

namespace Melior.InterviewQuestion.Tests
{
    public class DummyConfiguration : IConfiguration
    {
        public string GetDataStore()
        {
            return "hehehe";
        }
    }
}
