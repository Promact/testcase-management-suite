using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.DomainModel.Models.Scenario
{
    public class Scenario : TestCaseManagementBase
    {
        #region Public Properties

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ScenarioTestCaseMapping> ScenarioTestCaseMapping { get; set; }

        #endregion
    }
}