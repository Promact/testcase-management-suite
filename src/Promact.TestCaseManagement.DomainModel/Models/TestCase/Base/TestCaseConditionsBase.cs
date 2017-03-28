using Promact.TestCaseManagement.DomainModel.Enums;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase.Base
{
    public abstract class TestCaseConditionsBase
    {
        public int Id { get; set; }

        public Condition Condition { get; set; }

        public string Description { get; set; }

        public int? TestCaseId { get; set; }
    }
}
