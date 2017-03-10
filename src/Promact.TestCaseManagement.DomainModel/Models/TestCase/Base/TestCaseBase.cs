using Promact.TestCaseManagement.DomainModel.Models.Global;
using Promact.TestCaseManagement.DomainModel.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase.Base
{
    public class TestCaseBase : TestCaseManagementBase
    {
        #region Public Properties

        public int SerialNumber { get; set; }

        public string TestCaseId { get; set; }

        public string Description { get; set; }

        public string PreCondition { get; set; }

        public string PostCondition { get; set; }

        public int? DefectId { get; set; }

        public bool Priority { get; set; }

        public int PreparedBy { get; set; }

        public int? ReviewedBy { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public UserInfo CreatedUser { get; set; }

        [ForeignKey("ModifiedBy")]
        public UserInfo ModifiedUser { get; set; }

        #endregion
    }
}
