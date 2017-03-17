using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.Module
{
    public class ModuleTestCaseMapping : TestCaseManagementBase
    {
        #region Public Properties

        [Required]
        public int ModuleId { get; set; }

        [Required]
        public int TestCaseId { get; set; }

        [ForeignKey("ModuleId")]
        public virtual Module Module { get; set; }

        [ForeignKey("TestCaseId")]
        public virtual TestCase.TestCase TestCase { get; set; }

        #endregion
    }
}
