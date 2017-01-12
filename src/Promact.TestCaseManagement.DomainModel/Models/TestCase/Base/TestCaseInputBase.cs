using Promact.TestCaseManagement.DomainModel.Models.Global;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase.Base
{
    public abstract class TestCaseInputBase : TestCaseManagementBase
    {
        #region Public Properties

        public string TestInput { get; set; }

        #endregion
    }
}
