using Promact.TestCaseManagement.DomainModel.Models.Global;
using System;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase.Base
{
    public class TestCaseResultBase : TestCaseManagementBase
    {
        #region Public Properties

        public string ExpectedResult { get; set; }

        public DateTime ExpectedResultDate { get; set; }

        public string ActualResult { get; set; }

        public DateTime? ActualResultDate { get; set; }

        #endregion
    }
}
