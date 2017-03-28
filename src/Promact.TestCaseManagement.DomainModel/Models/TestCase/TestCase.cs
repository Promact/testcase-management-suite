using Promact.TestCaseManagement.DomainModel.Models.Module;
using Promact.TestCaseManagement.DomainModel.Models.Scenario;
using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;
using Promact.TestCaseManagement.DomainModel.Models.User;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCase : TestCaseBase
    {
        public string ReviewedBy { get; set; }

        [ForeignKey("ReviewedBy")]
        public virtual UserInfo ReviewedUser { get; set; }

        public virtual ICollection<TestCaseResultHistory> TestCaseResultHistory { get; set; }

        public virtual ICollection<TestCaseSteps> TestCaseSteps { get; set; }

        public virtual ICollection<TestCaseConditions> TestCaseConditions { get; set; }

        public virtual ICollection<ModuleTestCaseMapping> ModuleTestCaseMapping { get; set; }

        public virtual ICollection<ScenarioTestCaseMapping> ScenarioTestCaseMapping { get; set; }
    }
}