using Promact.TestCaseManagement.DomainModel.Models.Global;
using Promact.TestCaseManagement.DomainModel.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase.Base
{
    public abstract class TestCaseBase : TestCaseManagementBase
    {
        public string TestCaseUniqueId { get; set; }

        public string Description { get; set; }

        public int? DefectId { get; set; }

        public bool Priority { get; set; }

        public string CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual UserInfo CreatedUser { get; set; }
    }
}