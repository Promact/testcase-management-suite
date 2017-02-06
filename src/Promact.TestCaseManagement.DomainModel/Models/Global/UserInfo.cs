namespace Promact.TestCaseManagement.DomainModel.Models.Global
{
    public class UserInfo : TestCaseManagementBase
    {
        #region Public Properties

        public string Email { get; set; }

        public string UserId { get; set; }

        public string RefreshToken { get; set; }

        #endregion
    }
}