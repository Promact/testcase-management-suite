using Promact.TestCaseManagement.DomainModel.Models.Module;
using Promact.TestCaseManagement.DomainModel.Models.Scenario;
using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCase : TestCaseBase
    {
        #region Public Properties        

        public int TestCaseResultHistoryId { get; set; }

        [ForeignKey("TestCaseResultHistoryId")]
        public virtual TestCaseResultHistory TestCaseResultHistory { get; set; }

        public virtual ICollection<TestCaseSteps> TestCaseSteps { get; set; }

        public virtual ICollection<ModuleTestCaseMapping> ModuleTestCaseMapping { get; set; }

        public virtual ICollection<ScenarioTestCaseMapping> ScenarioTestCaseMapping { get; set; }

        #endregion
    }
}