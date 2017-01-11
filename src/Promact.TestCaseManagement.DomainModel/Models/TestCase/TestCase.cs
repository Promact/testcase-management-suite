using Promact.TestCaseManagement.DomainModel.Enums;
using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.Collections.Generic;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCase : TestCaseManagementBase
    {
        #region Constructor

        public TestCase()
        {
            TestCaseSteps = new List<TestCaseSteps>();
        }

        #endregion

        #region Public Properties

        public int SerialNumber { get; set; }

        public string TestCaseId { get; set; }

        public string Description { get; set; }

        public string PreCondition { get; set; }

        public string TestInput { get; set; }

        public TestCaseResultStatus TestCaseResultStatus { get; set; }

        public string PostCondition { get; set; }

        public int? DefectId { get; set; }

        public bool Priority { get; set; }

        public int PreparedBy { get; set; }

        public int? ReviewedBy { get; set; }

        public ICollection<TestCaseSteps> TestCaseSteps { get; set; }

        #endregion
    }
}