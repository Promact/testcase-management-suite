using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.DomainModel.Models.Module
{
    public class ModuleTestCaseMapping : TestCaseManagementBase
    {
        [Required]
        public int ModuleId { get; set; }

        [Required]
        public int TestCaseId { get; set; }

        public virtual Module Module { get; set; }

        public virtual TestCase.TestCase TestCase { get; set; }
    }
}
