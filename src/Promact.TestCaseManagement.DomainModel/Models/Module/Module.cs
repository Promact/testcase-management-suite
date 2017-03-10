using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.DomainModel.Models.Module
{
    public class Module : TestCaseManagementBase
    {
        #region Public Properties

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ModuleTestCaseMapping> ModelTestCaseMapping { get; set; }

        #endregion
    }
}