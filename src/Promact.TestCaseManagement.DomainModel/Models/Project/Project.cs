using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.DomainModel.Models.Project
{
    public class Project : TestCaseManagementBase
    {
        #region Public Properties

        [Required]
        public string Name { get; set; }

        public string Prerequisite { get; set; }

        public string TestEnvironment { get; set; }

        public string HardWare { get; set; }

        #endregion
    }
}