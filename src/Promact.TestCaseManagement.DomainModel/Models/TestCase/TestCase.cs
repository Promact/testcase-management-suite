using Promact.TestCaseManagement.DomainModel.Enums;
using Promact.TestCaseManagement.DomainModel.Models.Global;
using System;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCase : TestCaseManagementBase
    {
        public int SerialNumber { get; set; }

        public string TestCaseId { get; set; }

        public string Description { get; set; }

        public string PreCondition { get; set; }

        public string TestSteps { get; set; }

        public string TestInput { get; set; }

        public string ExpectedResult { get; set; }

        public DateTime ExpectedResultDate { get; set; }

        public string ActualResult { get; set; }

        public DateTime? ActualResultDate { get; set; }

        public TestCaseResult TestCaseResult { get; set; }

        public string PostCondition { get; set; }

        public int? DefectId { get; set; }

        public bool Priority { get; set; }

        public int PreparedBy { get; set; }

        public int? ReviewedBy { get; set; }
    }
}