using Promact.TestCaseManagement.DomainModel.Enums;
using Promact.TestCaseManagement.DomainModel.Models.Global;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase.Base
{
    public class TestCaseBase : TestCaseManagementBase
    {
        #region Public Properties

        public int SerialNumber { get; set; }

        public string TestCaseId { get; set; }

        public string Description { get; set; }

        public string PreCondition { get; set; }

        public TestCaseResultStatus TestCaseResultStatus { get; set; }

        public string PostCondition { get; set; }

        public int? DefectId { get; set; }

        public bool Priority { get; set; }

        public int PreparedBy { get; set; }

        public int? ReviewedBy { get; set; }

        #endregion
    }
}
