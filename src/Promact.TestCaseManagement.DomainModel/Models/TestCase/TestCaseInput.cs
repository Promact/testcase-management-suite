using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;
using System.Collections.Generic;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseInput : TestCaseInputBase
    {
        public int TestCaseStepsId { get; set; }

        public virtual TestCaseSteps TestCaseSteps { get; set; }

        public virtual ICollection<TestCaseInputVersion> TestCaseInputVersion { get; set; }
    }
}