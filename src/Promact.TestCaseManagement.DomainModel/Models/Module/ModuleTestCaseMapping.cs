using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.Module
{
    public class ModuleTestCaseMapping : TestCaseManagementBase
    {
        public int ModuleId { get; set; }

        public int TestCaseId { get; set; }

        [ForeignKey("ModuleId")]
        public virtual Module Module { get; set; }

        [ForeignKey("TestCaseId")]
        public virtual TestCase.TestCase TestCase { get; set; }
    }
}
