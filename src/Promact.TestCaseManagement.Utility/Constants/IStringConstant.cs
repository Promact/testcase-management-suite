namespace Promact.TestCaseManagement.Utility.Constants
{
    public interface IStringConstant
    {
        #region General Constants

        string Oidc { get; }

        string Cookies { get; }

        string OAuthUrl { get; }

        string ClientId { get; }

        string ClientSecret { get; }

        string OffLineAccess { get; }

        string Email { get; }

        string Sub { get; }

        string RefreshToken { get; }

        string ResponseType { get; }

        string OpenId { get; }

        string Profile { get; }

        string TestCaseManagement { get; }

        string ConnectionString { get; }

        string Appsettings { get; }

        string Bearer { get; }

        string TeamLeader { get; }

        string TeamMember { get; }

        #endregion

        #region API Path

        string ProjectDetail { get; }

        #endregion
    }
}
