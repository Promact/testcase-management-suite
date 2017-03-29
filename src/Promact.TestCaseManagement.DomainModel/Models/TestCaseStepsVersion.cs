namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class TestCaseStepsVersion : TestCaseStepsBase
    {
        public int TestCaseStepsId { get; set; }

        public virtual TestCaseSteps TestCaseSteps { get; set; }
    }
}
