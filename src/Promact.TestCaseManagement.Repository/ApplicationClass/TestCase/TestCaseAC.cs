using System.Collections.Generic;

namespace Promact.TestCaseManagement.Repository.ApplicationClass.TestCase
{
    public class TestCaseAC
    {
        public int Id { get; set; }

        public string TestCaseUniqueId { get; set; }

        public string Description { get; set; }

        public int? DefectId { get; set; }

        public bool Priority { get; set; }

        public IEnumerable<TestCaseConditionsAC> PreConditions { get; set; }

        public IEnumerable<TestCaseStepsAC> TestCaseSteps { get; set; }

        public IEnumerable<TestCaseConditionsAC> PostConditions { get; set; }
    }
}