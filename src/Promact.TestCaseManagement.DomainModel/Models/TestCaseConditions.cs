using System.Collections.Generic;

namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class TestCaseConditions : TestCaseConditionsBase
    {
        public bool IsDeleted { get; set; }

        public virtual TestCase TestCase { get; set; }

        public virtual ICollection<TestCaseConditionsVersion> TestCaseConditionsVersion { get; set; }
    }
}