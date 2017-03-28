using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;
using System.Collections.Generic;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseSteps : TestCaseStepsBase
    {
        public int TestCaseId { get; set; }

        public virtual TestCase TestCase { get; set; }

        public virtual ICollection<TestCaseInput> TestCaseInputs { get; set; }

        public virtual ICollection<TestCaseStepsVersion> TestCaseStepsVersion { get; set; }
    }
}