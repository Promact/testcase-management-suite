using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;
using System;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseConditionsVersion : TestCaseConditionsBase
    {
        public int TestCaseConditionsId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public virtual TestCaseConditions TestCaseConditions { get; set; }
    }
}