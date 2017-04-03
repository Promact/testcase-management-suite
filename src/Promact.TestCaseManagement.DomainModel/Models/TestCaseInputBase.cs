namespace Promact.TestCaseManagement.DomainModel.Models
{
    public abstract class TestCaseInputBase
    {
        public int Id { get; set; }

        public string TestInput { get; set; }

        public int TestCaseStepsId { get; set; }

        public int IsDeleted { get; set; }
    }
}