using System.Collections.Generic;

namespace Promact.TestCaseManagement.Repository.ApplicationClass.TestCase
{
    public class TestCaseStepsAC
    {
        public int Id { get; set; }

        public int TestCaseId { get; set; }

        public ICollection<TestCaseInputAc> TestCaseInputAC { get; set; }
    }
}
