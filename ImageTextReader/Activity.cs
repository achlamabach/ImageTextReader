using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImageTextReader
{
    public class Activity : IActivity
    {
        public ResponseText Response(string imageUrl)
        {
            string imageApi = string.Format(ApiConfiguration.Settings.ApiUrl,
                ApiConfiguration.Settings.ApiKey, imageUrl);

            string response = this.Get(imageApi);

            ResponseText responseText = JsonConvert.DeserializeObject<ResponseText>(response);
            

            return responseText;
        }

        public string Get(string url, int timeout = 10000)
        {
            if (url == null)
            {
                throw new ArgumentException("The url parameter is required.", url);
            }

            try
            {
                WebRequest request = this.GetWebRequest(url);
                request.Timeout = timeout;

                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;

                // Get the response.
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                        // Get the stream containing content returned by the server.
                        using (Stream dataStream = response.GetResponseStream())
                        {
                            if (dataStream != null)
                            {
                                // Open the stream using a StreamReader for easy access.
                                using (var reader = new StreamReader(dataStream))
                                {
                                    // Read the content.
                                    string responseFromServer = reader.ReadToEnd();
                                    return responseFromServer;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return string.Empty;
        }

        /// <summary>
        /// Gets the web request. Available so can be mocked out.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The web request.</returns>
        public virtual WebRequest GetWebRequest(string url)
        {
            WebRequest request = WebRequest.Create(url);
            return request;
        }
    }
}
