using Promact.TestCaseManagement.DomainModel.Models.Global;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase.Base
{
    public class TestCaseStepsBase : TestCaseManagementBase
    {
        #region Public Properties

        public int TestStepNumber { get; set; }

        public string TestStep { get; set; }

        #endregion
    }
}
