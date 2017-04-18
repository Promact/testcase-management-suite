namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class TestCaseVersion : TestCaseBase
    {
        public int TestCaseId { get; set; }

        public virtual TestCase TestCase { get; set; }
    }
}