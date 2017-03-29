using Promact.TestCaseManagement.DomainModel.Enums;

namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class ProjectUserMapping : TestCaseManagementBase
    {
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public string UserId { get; set; }

        public virtual UserInfo User { get; set; }

        public TeamRole Role { get; set; }
    }
}
