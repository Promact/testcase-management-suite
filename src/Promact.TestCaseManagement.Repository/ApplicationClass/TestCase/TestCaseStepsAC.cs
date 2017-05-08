using System;
using System.Collections.Generic;

namespace Promact.TestCaseManagement.Repository.ApplicationClass.TestCase
{
    public class TestCaseStepsAC
    {
        public int Id { get; set; }

        public int TestCaseId { get; set; }

        public string TestStep { get; set; }

        public string ExpectedResult { get; set; }

        public DateTime ExpectedResultDate { get; } = DateTime.UtcNow;

        public IEnumerable<TestCaseInputAc> TestCaseInputs { get; set; }
    }
}