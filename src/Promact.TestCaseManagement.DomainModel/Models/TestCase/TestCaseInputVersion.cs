using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseInputVersion : TestCaseInputBase
    {
        public int TestCaseInputId { get; set; }

        public virtual TestCaseInput TestCaseInput { get; set; }
    }
}