using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;
using System.Collections.Generic;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseConditions : TestCaseConditionsBase
    {
        public virtual TestCase TestCase { get; set; }

        public virtual ICollection<TestCaseConditionsVersion> TestCaseConditionsVersion { get; set; }
    }
}