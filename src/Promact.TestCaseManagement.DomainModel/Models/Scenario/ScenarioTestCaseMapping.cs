using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.Scenario
{
    public class ScenarioTestCaseMapping : TestCaseManagementBase
    {
        #region Public Properties

        [Required]
        public int ScenarioId { get; set; }

        [Required]
        public int TestCaseId { get; set; }

        [ForeignKey("ScenarioId")]
        public virtual Scenario Scenario { get; set; }

        [ForeignKey("TestCaseId")]
        public virtual TestCase.TestCase TestCase { get; set; }

        #endregion
    }
}
