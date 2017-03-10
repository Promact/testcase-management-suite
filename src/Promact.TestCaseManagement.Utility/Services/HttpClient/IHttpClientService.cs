using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Utility.Services.HttpClient
{
    public interface IHttpClientService
    {
        /// <summary>
        /// Method to make http call to another domain
        /// </summary>
        /// <param name="baseUrl">url of another domain</param>
        /// <param name="requestUri">request uri</param>
        /// <param name="accessToken">access token</param>
        /// <returns>responseContent</returns>
        Task<string> GetAsync(string baseUrl, string requestUri, string accessToken);
    }
}