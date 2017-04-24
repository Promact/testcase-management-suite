using IdentityModel.Client;
using Promact.TestCaseManagement.Utility.Constants;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Utility.Services.AccessToken
{
    public class AccessTokenService : IAccessTokenService
    {
        readonly IStringConstant _iStringConstant;

        #region Constructor

        public AccessTokenService(IStringConstant iStringConstant)
        {
            _iStringConstant = iStringConstant;
        }

        #endregion

        public async Task<string> GetAccessTokenByRefreshTokenAsync(string refreshToken)
        {
            var discovery = new DiscoveryClient(_iStringConstant.OAuthUrl);
            var doc = await discovery.GetAsync();
            var tokenClient = new TokenClient(doc.TokenEndpoint, _iStringConstant.ClientId, _iStringConstant.ClientSecret);
            var requestRefreshToken = await tokenClient.RequestRefreshTokenAsync(refreshToken);
            return requestRefreshToken.AccessToken;
        }
    }
}