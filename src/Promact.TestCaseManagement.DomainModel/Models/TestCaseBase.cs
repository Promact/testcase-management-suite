namespace Promact.TestCaseManagement.DomainModel.Models
{
    public abstract class TestCaseBase : TestCaseManagementBase
    {
        public string TestCaseUniqueId { get; set; }

        public string Description { get; set; }

        public int? DefectId { get; set; }

        public bool Priority { get; set; }

        public string CreatedUserId { get; set; }

        public virtual UserInfo CreatedUser { get; set; }
    }
}