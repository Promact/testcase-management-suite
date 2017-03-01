using Promact.TestCaseManagement.DomainModel.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.Global
{
    public class UserInfo : TestCaseManagementBase
    {
        #region Public Properties

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public TeamRole TeamRole { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string RefreshToken { get; set; }

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project.Project Project { get; set; }

        #endregion
    }
}