using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseTestStepsMapping : TestCaseManagementBase
    {
        public int TestCaseId { get; set; }

        public int TestCaseStepsId { get; set; }

        [ForeignKey("TestCaseId")]
        public TestCase TestCase { get; set; }

        [ForeignKey("TestCaseStepsId")]
        public TestCaseSteps TestCaseSteps { get; set; }
    }
}