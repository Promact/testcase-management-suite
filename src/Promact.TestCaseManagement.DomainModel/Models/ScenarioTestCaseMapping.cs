namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class ScenarioTestCaseMapping : TestCaseManagementBase
    {
        public int ScenarioId { get; set; }

        public int TestCaseId { get; set; }

        public virtual Scenario Scenario { get; set; }

        public virtual TestCase TestCase { get; set; }
    }
}
