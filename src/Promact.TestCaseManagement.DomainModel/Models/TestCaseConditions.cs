using System.Collections.Generic;

namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class TestCaseConditions : TestCaseConditionsBase
    {
        public virtual TestCase ReferenceTestCase { get; set; }

        public virtual TestCase TestCase { get; set; }

        public virtual ICollection<TestCaseConditionsVersion> TestCaseConditionsVersion { get; set; }
    }
}