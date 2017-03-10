using Promact.TestCaseManagement.Utility.Constants;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Utility.Services.HttpClient
{
    public class HttpClientService : IHttpClientService
    {
        /// <summary>
        /// Method to make http call to another domain
        /// </summary>
        /// <param name="baseUrl">url of another domain</param>
        /// <param name="requestUri">request uri</param>
        /// <param name="accessToken">access token</param>
        /// <returns>responseContent</returns>
        public async Task<string> GetAsync(string baseUrl, string requestUri, string accessToken)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.SetBearerToken(accessToken);
                }
                var response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                    return null;
            }
        }
    }
}
