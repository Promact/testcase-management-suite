using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseStepsVersion : TestCaseStepsBase
    {
        public int TestCaseStepsId { get; set; }

        public virtual TestCaseSteps TestCaseSteps { get; set; }
    }
}
