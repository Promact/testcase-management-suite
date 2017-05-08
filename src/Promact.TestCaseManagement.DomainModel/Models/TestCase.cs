using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class TestCase : TestCaseBase
    {
        public string ReviewedUserId { get; set; }

        public virtual UserInfo ReviewedUser { get; set; }

        public virtual ICollection<TestCaseResultHistory> TestCaseResultHistory { get; set; }

        public virtual ICollection<TestCaseSteps> TestCaseSteps { get; set; }

        [InverseProperty("TestCase")]
        public virtual ICollection<TestCaseConditions> TestCaseConditions { get; set; }

        public virtual ICollection<ModuleTestCaseMapping> ModuleTestCaseMapping { get; set; }

        public virtual ICollection<ScenarioTestCaseMapping> ScenarioTestCaseMapping { get; set; }
    }
}