using System.Configuration;

namespace ImageTextReader
{
    public class ApiConfiguration : ConfigurationSection
    {
        private static ApiConfiguration settings = ConfigurationManager.GetSection("ApiConfiguration") as ApiConfiguration;

        public static ApiConfiguration Settings
        {
            get
            {
                return settings;
            }
        }

        [ConfigurationProperty("apiKey", IsRequired = false)]
        public string ApiKey
        {
            get
            {
                return (string)this["apiKey"];
            }
        }

        [ConfigurationProperty("apiUrl", IsRequired = false)]
        public string ApiUrl
        {
            get
            {
                return (string)this["apiUrl"];
            }
        }
    }
}
