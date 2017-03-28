using Promact.TestCaseManagement.DomainModel.Models.Global;
using Promact.TestCaseManagement.DomainModel.Models.User;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.DomainModel.Models.Project
{
    public class Project : TestCaseManagementBase
    {
        [Required]
        public string Name { get; set; }

        public string Prerequisite { get; set; }

        public string TestEnvironment { get; set; }

        public string Hardware { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Module.Module> Module { get; set; }

        public virtual ICollection<Scenario.Scenario> Scenario { get; set; }

        public virtual ICollection<ProjectUserMapping> ProjectUserMapping { get; set; }
    }
}