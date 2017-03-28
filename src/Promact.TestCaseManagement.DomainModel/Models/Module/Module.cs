using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.DomainModel.Models.Module
{
    public class Module : TestCaseManagementBase
    {
        [Required]
        public string Name { get; set; }

        public int ProjectId { get; set; }

        public virtual Project.Project Project { get; set; }

        public virtual ICollection<ModuleTestCaseMapping> ModuleTestCaseMapping { get; set; }
    }
}