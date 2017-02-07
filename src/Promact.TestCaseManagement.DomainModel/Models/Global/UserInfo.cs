using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.DomainModel.Models.Global
{
    public class UserInfo : TestCaseManagementBase
    {
        #region Public Properties

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string RefreshToken { get; set; }

        #endregion
    }
}