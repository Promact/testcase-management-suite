using Promact.TestCaseManagement.DomainModel.Enums;

namespace Promact.TestCaseManagement.Repository.ApplicationClass.TestCase
{
    public class TestCaseConditionsAC
    {
        public int Id { get; set; }

        public Condition Condition { get; set; }

        public string Description { get; set; }

        public int? TestCaseId { get; set; }
    }
}