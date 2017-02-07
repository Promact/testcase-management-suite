using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.DomainModel.Models.Module
{
    public class Module : TestCaseManagementBase
    {
        #region Public Properties

        [Required]
        public string Name { get; set; }

        #endregion
    }
}