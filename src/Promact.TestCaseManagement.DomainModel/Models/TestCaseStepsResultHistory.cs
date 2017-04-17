using System;

namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class TestCaseStepsResultHistory
    {
        public int Id { get; set; }

        public string ActualResult { get; set; }

        public DateTime ActualResultDate { get; set; }

        public int TestCaseStepsId { get; set; }

        public string CreatedUserId { get; set; }

        public virtual UserInfo CreatedUser { get; set; }

        public virtual TestCaseSteps TestCaseSteps { get; set; }
    }
}
