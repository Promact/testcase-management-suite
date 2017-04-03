using Promact.TestCaseManagement.DomainModel.Enums;

namespace Promact.TestCaseManagement.DomainModel.Models
{
    public abstract class TestCaseConditionsBase
    {
        public int Id { get; set; }

        public Condition Condition { get; set; }

        public string Description { get; set; }

        public int? TestCaseId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
