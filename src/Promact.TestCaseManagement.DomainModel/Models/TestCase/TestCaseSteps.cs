using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseSteps : TestCaseManagementBase
    {
        public TestCaseSteps()
        {
            TestCaseInputs = new List<TestCaseInput>();
        }

        public int TestStepNumber { get; set; }

        public string TestStep { get; set; }

        public int TestCaseResultId { get; set; }

        public int TestCaseId { get; set; }

        [ForeignKey("TestCaseResultId")]
        public virtual TestCaseResult TestCaseResult { get; set; }

        [ForeignKey("TestCaseId")]
        public virtual TestCase TestCase { get; set; }

        public virtual ICollection<TestCaseInput> TestCaseInputs { get; set; }
    }
}