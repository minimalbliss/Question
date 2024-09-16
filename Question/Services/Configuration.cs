using System.Configuration;

namespace Melior.InterviewQuestion.Services
{
    public class Configuration : IConfiguration
    {
        private const string DataStoreTypeKey = "DataStoreType";

        public string GetDataStore()
        { 
            return ConfigurationManager.AppSettings[DataStoreTypeKey];
        }
}
}
