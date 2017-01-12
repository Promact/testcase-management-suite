using Promact.TestCaseManagement.DomainModel.Enums;
using Promact.TestCaseManagement.DomainModel.Models.Global;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseResultHistory : TestCaseManagementBase
    {
        #region Public Properties

        public int TestCaseId { get; set; }

        public TestCaseResultStatus TestCaseResult { get; set; }

        public virtual TestCase TestCase { get; set; }

        #endregion
    }
}