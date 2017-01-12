using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseStepsVersion : TestCaseStepsBase
    {
        #region Public Properties

        public int TestCaseStepsId { get; set; }

        [ForeignKey("TestCaseStepsId")]
        public virtual TestCaseSteps TestCaseSteps { get; set; }

        #endregion
    }
}
