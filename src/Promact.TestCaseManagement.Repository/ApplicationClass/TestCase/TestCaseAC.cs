using System.Collections.Generic;

namespace Promact.TestCaseManagement.Repository.ApplicationClass.TestCase
{
    public class TestCaseAC
    {
        public int Id { get; set; }

        public int SerialNumber { get; set; }

        public string TestCaseId { get; set; }

        public string Description { get; set; }

        public string PreCondition { get; set; }

        public string PostCondition { get; set; }

        public int? DefectId { get; set; }

        public bool Priority { get; set; }

        public int PreparedBy { get; set; }

        public int? ReviewedBy { get; set; }

        public ICollection<TestCaseStepsAC> TestCaseStepsAC { get; set; }
    }
}
