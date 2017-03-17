using IdentityModel.Client;
using Promact.TestCaseManagement.Utility.Constants;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Utility.Services.AccessToken
{
    public class AccessTokenService : IAccessTokenService
    {
        /// <summary>
        /// This method used for get access token by refresh token.
        /// </summary>
        /// <param name="refreshToken">passed refresh token</param>
        /// <returns>access token</returns>
        public async Task<string> GetAccessTokenByRefreshTokenAsync(string refreshToken)
        {
            var discovery = new DiscoveryClient(StringConstants.OAuthUrl);
            var doc = await discovery.GetAsync();
            var tokenClient = new TokenClient(doc.TokenEndpoint, StringConstants.ClientId, StringConstants.ClientSecret);
            var requestRefreshToken = await tokenClient.RequestRefreshTokenAsync(refreshToken);
            return requestRefreshToken.AccessToken;
        }
    }
}