using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.Scenario
{
    public class ScenarioTestCaseMapping : TestCaseManagementBase
    {
        public int ScenarioId { get; set; }

        public int TestCaseId { get; set; }

        [ForeignKey("ScenarioId")]
        public virtual Scenario Scenario { get; set; }

        [ForeignKey("TestCaseId")]
        public virtual TestCase.TestCase TestCase { get; set; }
    }
}
