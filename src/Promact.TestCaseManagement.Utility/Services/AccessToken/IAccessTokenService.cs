using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Utility.Services.AccessToken
{
    public interface IAccessTokenService
    {
        /// <summary>
        /// This method used for get access token by refresh token.
        /// </summary>
        /// <param name="refreshToken">passed refresh token</param>
        /// <returns>access token</returns>
        Task<string> GetAccessTokenByRefreshTokenAsync(string refreshToken);
    }
}
