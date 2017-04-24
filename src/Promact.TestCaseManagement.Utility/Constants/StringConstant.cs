namespace Promact.TestCaseManagement.Utility.Constants
{
    public class StringConstant : IStringConstant
    {
        public string Oidc { get { return "oidc"; } }
        public string Cookies { get { return "Cookies"; } }
        public string OAuthUrl { get { return "https://oauth.promactinfo.com/"; } }
        public string ClientId { get { return "HU6E99MN3C2CTK8"; } }
        public string ClientSecret { get { return "wUOC7scxfffqBThJdzAybF1wSqms0S"; } }
        public string OffLineAccess { get { return "offline_access"; } }
        public string Email { get { return "email"; } }
        public string Sub { get { return "sub"; } }
        public string RefreshToken { get { return "refresh_token"; } }
        public string ResponseType { get { return "code id_token"; } }
        public string OpenId { get { return "openid"; } }
        public string Profile { get { return "profile"; } }
        public string TestCaseManagement { get { return "TestCaseManagement"; } }
        public string ConnectionString { get { return "DefaultConnection"; } }
        public string Appsettings { get { return "appsettings.json"; } }
        public string Bearer { get { return "Bearer"; } }
        public string TeamLeader { get { return "TeamLeader"; } }
        public string TeamMember { get { return "TeamMember"; } }

        #region API Path

        public string ProjectDetail { get { return "api/users/details"; } }

        #endregion

    }
}