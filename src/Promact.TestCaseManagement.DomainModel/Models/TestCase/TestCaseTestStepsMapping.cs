using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseTestStepsMapping : TestCaseManagementBase
    {
        #region Public Properties

        public int TestCaseId { get; set; }

        public int TestCaseStepsId { get; set; }

        [ForeignKey("TestCaseId")]
        public virtual TestCase TestCase { get; set; }

        [ForeignKey("TestCaseStepsId")]
        public virtual TestCaseSteps TestCaseSteps { get; set; }

        #endregion
    }
}