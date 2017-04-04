using System;

namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class TestCaseInputVersion : TestCaseInputBase
    {
        public DateTime CreatedDateTime { get; set; }

        public int TestCaseInputId { get; set; }

        public string CreatedUserId { get; set; }

        public virtual UserInfo CreatedUser { get; set; }

        public virtual TestCaseInput TestCaseInput { get; set; }
    }
}