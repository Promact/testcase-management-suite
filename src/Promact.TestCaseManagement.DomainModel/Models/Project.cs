using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.DomainModel.Models
{
    public class Project : TestCaseManagementBase
    {
        [Required]
        public string Name { get; set; }

        public string Prerequisite { get; set; }

        public string TestEnvironment { get; set; }

        public string Hardware { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<Module> Module { get; set; }

        public virtual ICollection<Scenario> Scenario { get; set; }

        public virtual ICollection<ProjectUserMapping> ProjectUserMapping { get; set; }
    }
}