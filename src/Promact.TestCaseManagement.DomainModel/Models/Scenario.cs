using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class Scenario : TestCaseManagementBase
    {
        [Required]
        public string Name { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<ScenarioTestCaseMapping> ScenarioTestCaseMapping { get; set; }
    }
}