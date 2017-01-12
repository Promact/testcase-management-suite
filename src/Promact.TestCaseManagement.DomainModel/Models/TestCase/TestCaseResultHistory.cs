using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseResultHistory : TestCaseResultBase
    {
        public int TestCaseResultId { get; set; }

        [ForeignKey("TestCaseResultId")]
        public TestCaseResult TestCaseResult { get; set; }
    }
}