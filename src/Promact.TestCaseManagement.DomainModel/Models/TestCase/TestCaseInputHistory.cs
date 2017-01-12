using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseInputHistory : TestCaseInputBase
    {
        public int TestCaseInputId { get; set; }

        [ForeignKey("TestCaseInputId")]
        public virtual TestCaseInput TestCaseInput { get; set; }
    }
}