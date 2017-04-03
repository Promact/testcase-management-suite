using System.Collections.Generic;

namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class TestCaseInput : TestCaseInputBase
    {
        public virtual TestCaseSteps TestCaseSteps { get; set; }

        public virtual ICollection<TestCaseInputVersion> TestCaseInputVersion { get; set; }
    }
}