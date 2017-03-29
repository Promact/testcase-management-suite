namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class TestCaseInputVersion : TestCaseInputBase
    {
        public int TestCaseInputId { get; set; }

        public virtual TestCaseInput TestCaseInput { get; set; }
    }
}