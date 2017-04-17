using System.Collections.Generic;

namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class TestCaseSteps : TestCaseStepsBase
    {
        public virtual TestCase TestCase { get; set; }

        public virtual ICollection<TestCaseInput> TestCaseInputs { get; set; }

        public virtual ICollection<TestCaseStepsVersion> TestCaseStepsVersion { get; set; }

        public virtual ICollection<TestCaseStepsResultHistory> TestCaseStepsResultHistory { get; set; }
    }
}