using Promact.TestCaseManagement.DomainModel.Models.Global;
using System;
using System.Collections.Generic;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseResult : TestCaseManagementBase
    {
        public TestCaseResult()
        {
            TestCaseSteps = new List<TestCaseSteps>();
        }

        public string ExpectedResult { get; set; }

        public DateTime ExpectedResultDate { get; set; }

        public string ActualResult { get; set; }

        public DateTime? ActualResultDate { get; set; }

        public virtual ICollection<TestCaseSteps> TestCaseSteps { get; set; }
    }
}