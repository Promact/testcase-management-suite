using Promact.TestCaseManagement.DomainModel.Models.Global;
using System;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase.Base
{
    public abstract class TestCaseStepsBase : TestCaseManagementBase
    {
        #region Public Properties

        public int TestStepNumber { get; set; }

        public string TestStep { get; set; }

        public string ExpectedResult { get; set; }

        public DateTime ExpectedResultDate { get; set; }

        public string ActualResult { get; set; }

        public DateTime? ActualResultDate { get; set; }

        #endregion
    }
}
