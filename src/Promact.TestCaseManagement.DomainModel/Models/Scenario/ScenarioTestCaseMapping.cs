using Promact.TestCaseManagement.DomainModel.Models.Global;

namespace Promact.TestCaseManagement.DomainModel.Models.Scenario
{
    public class ScenarioTestCaseMapping : TestCaseManagementBase
    {
        public int ScenarioId { get; set; }

        public int TestCaseId { get; set; }

        public virtual Scenario Scenario { get; set; }

        public virtual TestCase.TestCase TestCase { get; set; }
    }
}
