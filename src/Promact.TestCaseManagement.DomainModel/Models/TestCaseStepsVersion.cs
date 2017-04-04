using System;

namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class TestCaseStepsVersion : TestCaseStepsBase
    {
        public DateTime CreatedDateTime { get; set; }

        public int TestCaseStepsId { get; set; }

        public string CreatedUserId { get; set; }

        public virtual UserInfo CreatedUser { get; set; }

        public virtual TestCaseSteps TestCaseSteps { get; set; }
    }
}