using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseInput : TestCaseManagementBase
   {
        public string TestInput { get; set; }

        public int TestCaseStepsId { get; set; }

        [ForeignKey("TestCaseStepsId")]
        public TestCaseSteps TestCaseSteps { get; set; }
    }
}