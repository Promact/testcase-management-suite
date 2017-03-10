using Promact.TestCaseManagement.DomainModel.Enums;
using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.User
{
    public class ProjectUserMapping : TestCaseManagementBase
    {
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project.Project Project { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserInfo User { get; set; }

        public TeamRole Role { get; set; }
    }
}
